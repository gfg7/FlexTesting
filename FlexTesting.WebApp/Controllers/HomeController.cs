using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlexTesting.WebApp.Models;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace FlexTesting.WebApp.Controllers
{
    [Inject]
    public partial class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;


        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetCurrentUser(User?.Identity?.Name));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}