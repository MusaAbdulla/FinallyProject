using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TourismReserve.BL.Extensions;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.Commons;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.BL.ViewModels.UserImageVM;
using TourismRserve.DAL.Context;

namespace TourismReserve.Controllers
{
    public class HomeController(TourismDbContext _context,IUserImageService _service,IWebHostEnvironment _env) : Controller
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
        [HttpGet]
        public async Task<IActionResult> UserImage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserImage(UserImageCreateVM vm)
        {
            if (vm.Image != null)
            {
                if (!vm.Image.IsValidType("image"))
                {
                    ModelState.AddModelError("Image", "File must be an image");
                    return View();
                }


                if (!vm.Image.IsValidSize(400))
                {
                    ModelState.AddModelError("Image", "File must be less than 400kb");
                    return View();
                }
            }
            await vm.Image.UploadAsync(_env.WebRootPath, "imgs", "usr");
            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(MyProfile));

        }
    }
}
