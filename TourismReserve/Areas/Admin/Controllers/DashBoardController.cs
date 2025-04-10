using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourismReserve.BL.Helper;

namespace TourismReserve.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Roles =RoleConstant.Musa)]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
