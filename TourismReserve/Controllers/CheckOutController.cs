using Microsoft.AspNetCore.Mvc;
using TourismReserve.BL.External_Service;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.Check;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly ITourPackageService _packageService;
        private readonly IChechOutService _checkoutService;
        private readonly IStripeService _stripeService;

        public CheckOutController(ITourPackageService packageService, IChechOutService checkoutService, IStripeService stripeService)
        {
            _packageService = packageService;
            _checkoutService = checkoutService;
            _stripeService = stripeService;
        }
        public async Task<IActionResult> Index()
        {
            // Tur paketlərini almaq üçün _packageService istifadə edin
            var tourPackages = await _packageService.GetAsync();
            // Tur paketlərini View-a göndərin
            return View(tourPackages);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(CheckOutVM checkoutDto)
        {

            var checkout = new CheckOut
            {
                FirstName = checkoutDto.FirstName,
                LastName = checkoutDto.LastName,
                PhoneNumber = checkoutDto.PhoneNumber,
                Address = checkoutDto.Address,
                City = checkoutDto.City,
                State = checkoutDto.State,
                Country = checkoutDto.Country,
                Email = checkoutDto.Email,
                TotalPrice = checkoutDto.TotalPrice
            };

            await _checkoutService.AddCheckoutAsync(checkout);
            var sessionUrl = await _stripeService.CreateCheckoutSession(checkoutDto.TotalPrice, "usd");

            return Redirect(sessionUrl);
        }

    }
}
