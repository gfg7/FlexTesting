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
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.WebApp.Controllers
{
    [Inject]
    [Authorize]
    public partial class FolderController : Controller
    {
        private readonly IFolderService _folderService;
        private readonly IUserService _userService;
        private readonly ConstructKanbanCommand _constructKanbanCommand;

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
                return Redirect("/Folder/Folders/" + result.Id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dto);
            }             
        }

        public async Task<ActionResult> UsersFolders()
        {
            var user = await _userService.GetCurrentUser(User.Identity?.Name);
            if (User?.Identity?.IsAuthenticated==true)
            {
                var vm = await _folderService.GetByUser(user.Id);
                return PartialView("FolderStack", vm);
            }
            return null;
        }

        public async Task<IActionResult> RenameFolder(string id, string title)
        {
            try
            {
                var renamedFolder = new RenameFolderDto() { FolderId = id, NewName = title};
                await _folderService.RenameFolder(renamedFolder);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Redirect("/Folder/Folders/" + id);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteFolder(string id, bool safeDelete)
        {
            try
            {
                await _folderService.DeleteFolder(id,safeDelete);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}