using Microsoft.AspNetCore.Mvc;

namespace TourismReserve.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
