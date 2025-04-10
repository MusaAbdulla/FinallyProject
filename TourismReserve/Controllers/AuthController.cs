using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TourismReserve.BL.Extensions;
using TourismReserve.BL.ViewModels.AuthVM;
using TourismReserve.Core.Enums;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.Controllers
{
    public class AuthController(UserManager<User> _userManager,SignInManager<User> _signinManger,RoleManager<IdentityRole> _role,IMapper _mapper) : Controller
    {
        public bool IsAuthenticated => HttpContext.User.Identity?.IsAuthenticated ?? false;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if(!ModelState.IsValid) 
            return View();
            var u= _mapper.Map<User>(vm);
            var result = await _userManager.CreateAsync(u,vm.Password);
            if(!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
                return View();
            }
            var resultt = await _userManager.AddToRoleAsync(u, nameof(Roles.Moderator));
            if(!resultt.Succeeded)
            {
                foreach (var item in resultt.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();  
            }
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Role()
        {
            foreach (Roles item in Enum.GetValues(typeof(Roles)))
            {
                await _role.CreateAsync(new IdentityRole(item.GetRole()));
            }
            return Ok();
        }
        public async Task<IActionResult> Login()
        {
            if (IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm,  string? returnUrl = null)
        {
            if (IsAuthenticated) return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            return View();
            User? user = null;  
            if (vm.UsernameorEmail.Contains("@"))
            user= await _userManager.FindByEmailAsync(vm.UsernameorEmail);
            else
            user= await _userManager.FindByNameAsync(vm.UsernameorEmail);
            if(user == null)
            {
                ModelState.AddModelError("", "Username or Password is wrong!");
                return View();
            }
            var result = await _signinManger.PasswordSignInAsync(user, vm.Password, vm.RememberMe, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "wait until" + user.LockoutEnd!
                    .Value.ToString("yyyy-MM-dd HH-mm-ss"));
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Username or Password is wrong!");
                }
                return View();
            }
            if (string.IsNullOrEmpty(returnUrl))
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToAction("Index", new { Controller = "DashBoard", Area = "Admin" });
                }
            return RedirectToAction("Index", "Home");
            return LocalRedirect(returnUrl);
          
          
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signinManger.SignOutAsync();

            return RedirectToAction("Index","Home");
        }
    }
}
