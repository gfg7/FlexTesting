using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Contract.TaskStatus.Dtos;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexTesting.WebApp.Controllers
{
    [Inject]
    public partial class StatusController : Controller
    {
        readonly ITaskStatusService _taskStatusService;
        readonly ITaskStatusWriteOperations _taskStatusWriteOperations;
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteStatus(string id, bool safeDelete=true)
        {
            try
            {
                await _taskStatusService.Delete(id, safeDelete);
            }
            catch {}
            return Redirect("/Folder/Folders/" + id);
        }

        [ActionName("Create")]
        public async Task<IActionResult> CreateStatus(string folderId, string title)
        {
            try
            {
                var status = new CreateStatusDto() {
                FolderId = folderId,
                Name = title
                };
                var item = await _taskStatusService.Create(status);
                return Json(item.Id);
            }
            catch {}
            return Redirect("/Folder/Folders/" + folderId);
        }

        [ActionName("Order")]
        [HttpPost]
        public async Task<ActionResult> OrderStatuses(string folderId, string order)
        {
            try
            {
                string[] ids = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(order)).Split(',');
                var statuses = await _taskStatusService.GetByFolder(folderId);
                for (int i = 0; i < ids.Length; i++)
                {
                        var status = statuses.Where(x => x.Id == ids[i]).First();
                        status.NextStatusId = i + 1 < ids.Length? ids[i + 1] : null;
                        await _taskStatusWriteOperations.UpdateOne(ids[i], status);
                }

            return Ok();
            }
            catch 
            {
            return BadRequest();
            }
        }
    }
}
