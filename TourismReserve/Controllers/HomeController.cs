using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TourismReserve.BL.ViewModels.Commons;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismRserve.DAL.Context;

namespace TourismReserve.Controllers
{
    public class HomeController(TourismDbContext _context) : Controller
    {

        public async Task<IActionResult> Index()
        {
            HomeVM vm= new HomeVM();
            vm.Sliders=await _context.Slides
                .Where(x => !x.IsDeleted)
                .Select(x => new SlideGetVM
                {
                 Image=x.ImageUrl,

                }).ToListAsync();
            return View(vm);
        }
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
