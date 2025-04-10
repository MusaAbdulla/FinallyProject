using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismReserve.BL.Extensions;
using TourismReserve.BL.Helper;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismRserve.DAL.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TourismReserve.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = RoleConstant.Musa)]
    public class SlideController(ISlideServices _service, TourismDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Slides.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SlideCreateVM vm)
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
            await _service.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, SlideUpdateVM vm)
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
        
            if (!ModelState.IsValid) return View();
            await _service.UpdateAsync(vm, id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
