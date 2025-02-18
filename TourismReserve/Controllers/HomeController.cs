using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
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
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var data = await _context.Images
        //    .Where(x => x.Id == id.Value && !x.IsDeleted)
        //    .FirstOrDefaultAsync();
        //    if (data == null) return NotFound();
        //    return View(data);
        //}

        [HttpPost]
        public async Task<IActionResult> UserImage(UserImageCreateVM vm)
        {
            if (vm.Image != null)
            {
                if (!vm.Image.IsValidType("Image"))
                {
                    ModelState.AddModelError("Image", "File must be an image");
                
                }


                if (!vm.Image.IsValidSize(400))
                {
                    ModelState.AddModelError("Image", "File must be less than 400kb");
                   
                }
            }
            await vm.Image.UploadAsync(_env.WebRootPath, "imgs", "usr");
            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(MyProfile));

        }
    }
}
