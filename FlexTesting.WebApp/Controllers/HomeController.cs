using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.User;
using FlexTesting.WebApp.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlexTesting.WebApp.Models;
using FlexTesting.WebApp.Helpers;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace FlexTesting.WebApp.Controllers
{
    [Inject]
    public partial class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConstructMainPageCommand _constructMainPageCommand;


        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var vm = await _constructMainPageCommand.ConstructMainPage(User?.Identity?.Name);
                if (User?.Identity?.IsAuthenticated == true)
                {
                    TempData.Add<IEnumerable<Folder>>("main", vm.Folders);
                }
                return View(vm);
            }
            catch (NotFoundException e)
            {
                return RedirectToAction("Login", "Account");
            }
            catch (BusinessException ex)
            {
                return View("Error", ErrorViewModel.WithError(ex.Message));
            }

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