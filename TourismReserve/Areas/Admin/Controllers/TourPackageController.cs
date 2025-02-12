using Microsoft.AspNetCore.Mvc;
using TourismReserve.BL.Extensions;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.BL.ViewModels.TourPackageVM;

namespace TourismReserve.Areas.Admin.Controllers
{
    public class TourPackageController(ITourPackageService _service,IWebHostEnvironment _env) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TourPackageCreateVM vm)
        {
            if (vm.CoverImage != null)
            {
                if (!vm.CoverImage.IsValidType("image"))
                {
                    ModelState.AddModelError("Image", "File must be an image");
                    return View();
                }


                if (!vm.CoverImage.IsValidSize(400))
                {
                    ModelState.AddModelError("Image", "File must be less than 400kb");
                    return View();
                }
            }
            await vm.CoverImage.UploadAsync(_env.WebRootPath, "imgs", "sldrs");
            await _service.CreateAsync(vm);
            return RedirectToAction("Index");
        }
    }
}
