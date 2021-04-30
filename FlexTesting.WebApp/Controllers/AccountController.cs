using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Contract.User.Dtos;
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
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userService.Login(login);
                    await Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(login);
        }
        
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Token)
            };
            // создаем объект ClaimsIdentity
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}