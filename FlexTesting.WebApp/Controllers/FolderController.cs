using System;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Folder.Dtos;
using FlexTesting.Core.Contract.User;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlexTesting.WebApp.Controllers
{
    [Inject]
    [Authorize]
    public partial class FolderController : Controller
    {
        private readonly IFolderService _folderService;
        private readonly IUserService _userService;

        public async Task<IActionResult> Folders(string id)
        {
            var folder = await _folderService.ById(id);
            if(folder is not null)
                return View(folder);

            return NoContent();
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