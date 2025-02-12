using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TourismReserve.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
