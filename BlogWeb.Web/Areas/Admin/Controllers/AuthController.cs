using BlogWeb.Entity.DTOs.Users;
using BlogWeb.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByEmailAsync(userLoginDTO.Email);
                if (user != null) 
                { 
                    var result = await signInManager.PasswordSignInAsync(await user, userLoginDTO.Password,userLoginDTO.RememberMe,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new {Area = "Admin"});
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-postanız veya şifreniz yanlış.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-postanız veya şifreniz yanlış.");
                    return View();
                }
            }
            else
            {
                return View();
            }
           
        }
        
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
