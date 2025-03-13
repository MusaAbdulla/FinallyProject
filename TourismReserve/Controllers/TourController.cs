using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.Commons;
using TourismReserve.BL.ViewModels.ReservationVM;
using TourismReserve.BL.ViewModels.TourPackageVM;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;
using TourismRserve.DAL.Context;

namespace TourismReserve.Controllers
{
    public class TourController(IReservationServcie _service,IReservationRepository _repo, TourismDbContext _context) : Controller
    {
        public async Task< IActionResult> Index()
        {
            HomeVM vm = new HomeVM();
            vm.TourPackage = await _context.TourPackages.Select(x => new TourPackageGetVM
            {
                Id = x.Id,
                CoverImage = x.CoverImage,
                DisCount = x.DisCount,
                OtherImages=x.OtherImages,
                SellPrice = x.SellPrice,
                Name = x.Name,
                DepartureTime = x.DepartureTime,
                ReturnTime  = x.ReturnTime,
                Description = x.Description,
                Location = x.Location,
                Day = x.Day,
                Person = x.Person,
            }
          ).ToListAsync();
            return View(vm);
        }
        
        public async Task<IActionResult> Details(int? id)
        {

            if (!id.HasValue) return BadRequest();
            var data = await _context.TourPackages
            .Include(x=> x.Images)
            .Include(x=> x.Comments)
            .Where(x => x.Id == id.Value && !x.IsDeleted)
            .FirstOrDefaultAsync();
            if (data == null) return NotFound();

            return View(data);
        }
       
        
        [HttpPost]
     
        public async Task <IActionResult> Reserv( string number,string fullname ,int adult, int children, int youth, int? packageId)
        {
            if (!packageId.HasValue) return BadRequest();
            if (!await _context.TourPackages.AnyAsync(p => p.Id == packageId)) return NotFound();
            await _context.Reservations.AddAsync(new Reservation
            {
             
                TourPackageId = packageId.Value,
                Number= number,
                FullName = fullname,
                Adult =adult,
                Children= children,
                Youth= youth,
            });
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = packageId });
        }
     
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Comment(int? productId, string? comment,string userName)
        {

            if (!productId.HasValue) return BadRequest();
            string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            if (!await _context.TourPackages.AnyAsync(p => p.Id == productId)) return NotFound();



            await _context.Comments.AddAsync(new PackageComment
            {
                CreatedTime = DateTime.Now,
                IsDeleted = false,
                UserName = userName, 
                PackageId = productId.Value,
                Comment = comment,
                UserId = userId
            });



            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = productId });
        }
    }
}
