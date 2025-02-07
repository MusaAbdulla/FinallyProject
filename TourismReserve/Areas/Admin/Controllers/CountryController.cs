using Microsoft.AspNetCore.Mvc;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.CountryVM;

namespace TourismReserve.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountryController(ICountryService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CountryCreateVM vm)
        {
            await _service.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
