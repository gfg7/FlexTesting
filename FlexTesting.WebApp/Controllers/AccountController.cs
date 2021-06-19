using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Contract.User.Dtos;
using FlexTesting.WebApp.Models;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FlexTesting.WebApp.Controllers
{
    [Inject]
    public partial class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model)
        {
            try
            {
                var user = await _userService.Login(model);
                await Authenticate(user);
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(NewUserDto newUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    newUser.Url = Request.Scheme + "://" + Request.Host.ToUriComponent(); 
                    var user = await _userService.Register(newUser);
                    await Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            return View(newUser);
        }

        [HttpGet]
        public async Task<IActionResult> Confirm(string id, string code)
        {
            try
            {
                await _emailService.ConfirmEmail(new(id, code));
            }
            catch (BusinessException e)
            {
                return View("Error", new ErrorViewModel());
            }

            return RedirectToAction("Index", "Home");
        }
        
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Token),
            };
            // создаем объект ClaimsIdentity
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        
        public async Task<IActionResult> Logout()
        {
            await _userService.UnsetToken(User?.Identity?.Name);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData.Remove("main");
            return RedirectToAction("Login", "Account");
        }
    }
}