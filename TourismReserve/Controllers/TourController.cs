using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.ReservationVM;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;
using TourismRserve.DAL.Context;

namespace TourismReserve.Controllers
{
    public class TourController(IReservationServcie _service,IReservationRepository _repo, TourismDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {

            if (!id.HasValue) return BadRequest();
            var data = await _context.TourPackages
            .Include(x => x.Images)
            .Where(x => x.Id == id.Value && !x.IsDeleted)
            .FirstOrDefaultAsync();
            if (data == null) return NotFound();
            string? userId = User.Claims.FirstOrDefault(x => x.Type ==
            ClaimTypes.NameIdentifier)?.Value;
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Reserv(ReservationCreateVM vm,int? packageId)
        {
            if (!packageId.HasValue) return BadRequest();
            string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            if (!await _context.TourPackages.AnyAsync(p => p.Id == packageId)) return NotFound();
            await _context.Reservations.AddAsync(new Reservation
            {
                CreatedTime = DateTime.Now,
                IsDeleted = false,
                TourPackageId = packageId.Value,
                FullName=vm.FullName,
                Email=vm.Email,
                Adult=vm.Adult,
                Youth=vm.Youth,
                Children=vm.Children,
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = packageId });
        }
    }
}
