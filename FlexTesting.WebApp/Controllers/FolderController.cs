using System;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Folder.Dtos;
using FlexTesting.Core.Contract.User;
using FlexTesting.WebApp.Commands;
using FlexTesting.WebApp.Models;
using FlexTesting.WebApp.Helpers;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Issue;

namespace FlexTesting.WebApp.Controllers
{
    [Inject]
    [Authorize]
    public partial class FolderController : Controller
    {
        private readonly IFolderService _folderService;
        private readonly IUserService _userService;
        private readonly ConstructKanbanCommand _constructKanbanCommand;
        private readonly IIssueService _issueService;

        public async Task<IActionResult> Folders(string id)
        {
            try
            {
                var vm = await _constructKanbanCommand.Construct(id);
                return View(vm);
            }
            catch (BusinessException e)
            {
                return View("Error", ErrorViewModel.WithError(e.Message));
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFolderDto dto)
        {
            try
            {
                var user = await _userService.GetCurrentUser(User.Identity?.Name);
                dto.UserId = user.Id;
                var result = await _folderService.CreateFolder(dto);
                var vm = await _folderService.GetByUser(user.Id);
                TempData.Add<IEnumerable<Core.Contract.Models.Folder>>("main", vm);
                return Redirect("/Folder/Folders/" + result.Id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dto);
            }             
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteFolder(string id)
        {
            try
            {
                await _folderService.DeleteFolder(id);
            }
            catch (Exception e)
            {
                return Redirect("/Folder/Folders/" + id);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}