using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sociala__Web_UI_.Entities;
using Sociala__Web_UI_.Helpers;
using Sociala__Web_UI_.Models;

namespace Sociala__Web_UI_.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;
        private IHttpContextAccessor _contextAccessor;
        private IWebHostEnvironment _webHostEnvironment;

        public AccountController(UserManager<CustomIdentityUser> userManager,
            RoleManager<CustomIdentityRole> roleManager,
            SignInManager<CustomIdentityUser> signInManager, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.Username,
                    loginViewModel.Password, loginViewModel.RemeberMe, false).Result;
                if (result.Succeeded)
                {
                    var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
                    UserHelper.CurrentUser = user;

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login");
            }
            return View(loginViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var helper = new ImageHelper(_webHostEnvironment);

            if (registerViewModel.FilePath != null)
            {

                if (registerViewModel.FilePath.Length >= 555555)
                {

                    registerViewModel.ImageUrl = await helper.SaveFile(registerViewModel.Name, registerViewModel.FilePath);

                }

                if (ModelState.IsValid)
                {
                    CustomIdentityUser user = new CustomIdentityUser
                    {
                        UserName = registerViewModel.Name,
                        Email = registerViewModel.EmailAdress,
                        ProfilePicture = registerViewModel.ImageUrl

                    };

                    IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                    if (result.Succeeded)
                    {
                        if (!_roleManager.RoleExistsAsync("Admin").Result)
                        {
                            CustomIdentityRole role = new CustomIdentityRole
                            {
                                Name = "Admin"
                            };

                            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                            if (!roleResult.Succeeded)
                            {
                                ModelState.AddModelError("", "We can not add the role");
                                return View(registerViewModel);
                            }
                        }
                        _userManager.AddToRoleAsync(user, "Admin").Wait();
                        return RedirectToAction("Login");
                    }


                }

            }

        
            return View(registerViewModel);
        }

        public IActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

    }
}
