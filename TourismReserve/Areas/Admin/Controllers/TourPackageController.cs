using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismReserve.BL.Extensions;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.BL.ViewModels.TourPackageVM;
using TourismReserve.Core.Models.Commons;
using TourismRserve.DAL.Context;

namespace TourismReserve.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TourPackageController(ITourPackageService _service,IWebHostEnvironment _env, TourismDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.TourPackages.Include(x=> x.Country).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Countries.Where(x => !x.IsDeleted).ToListAsync();
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
            if (vm.OtherImages != null && vm.OtherImages.Any())
            {
                if (!vm.OtherImages.All(x => x.IsValidType("image")))
                {
                    string fileNames = string.Join(',', vm.OtherImages.Where(x => !x.IsValidType("image")).Select(x => x.FileName));
                    ModelState.AddModelError("OtherImages", fileNames + " is (are) not an image");
                }
                if (!vm.OtherImages.All(x => x.IsValidSize(400)))
                {
                    string fileNames = string.Join(',', vm.OtherImages.Where(x => !x.IsValidSize(400)).Select(x => x.FileName));
                    ModelState.AddModelError("OtherImages", fileNames + " is (are) bigger than 400kb");
                }
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Countries.Where(x => !x.IsDeleted).ToListAsync();
                return View(vm);
            }
            if (!await _context.Countries.AnyAsync(x => x.Id == vm.CountryId))
            {
                ViewBag.Categories = await _context.Countries.Where(x => !x.IsDeleted).ToListAsync();
                ModelState.AddModelError("CountryId", "Country not found");
                return View();
            }
          
            await _service.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await _context.Countries.Where(x => !x.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, TourPackageUpdateVM vm)
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
            if (vm.OtherImages != null && vm.OtherImages.Any())
            {
                if (!vm.OtherImages.All(x => x.IsValidType("image")))
                {
                    string fileNames = string.Join(',', vm.OtherImages.Where(x => !x.IsValidType("image")).Select(x => x.FileName));
                    ModelState.AddModelError("OtherImages", fileNames + " is (are) not an image");
                }
                if (!vm.OtherImages.All(x => x.IsValidSize(400)))
                {
                    string fileNames = string.Join(',', vm.OtherImages.Where(x => !x.IsValidSize(400)).Select(x => x.FileName));
                    ModelState.AddModelError("OtherImages", fileNames + " is (are) bigger than 400kb");
                }
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Countries.Where(x => !x.IsDeleted).ToListAsync();
                return View(vm);
            }
            if (!await _context.Countries.AnyAsync(x => x.Id == vm.CountryId))
            {
                ViewBag.Categories = await _context.Countries.Where(x => !x.IsDeleted).ToListAsync();
                ModelState.AddModelError("CountryId", "Country not found");
                return View();
            }
            TourPackage tourPackage = vm;
            if (vm.OtherImages != null)
            {
                tourPackage.Images = vm.OtherImages.Select(x => new TourPackageImage
                {
                    ImageUrl = x.UploadAsync(_env.WebRootPath, "imgs", "TR").Result
                }).ToList();
            }


            if (vm.CoverImage != null)
            {
                tourPackage.CoverImage = await vm.CoverImage.UploadAsync(_env.WebRootPath, "imgs", "TR");
            }
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
