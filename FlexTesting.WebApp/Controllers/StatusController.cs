using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Contract.TaskStatus.Dtos;
using FlexTesting.WebApp.Commands;
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
        private readonly ITaskStatusService _taskStatusService;
        private readonly ITaskStatusGetOperations _taskStatusGetOperations;
        private readonly IFolderGetOperations _folderGetOperations;
        private readonly IFolderService _folderService;
        private readonly IFolderWriteOperations _folderWriteOperations;
        private readonly ConstructKanbanCommand _constructKanbanCommand;
        private readonly IIssueGetOperations _issueGetOperations;
        private readonly IIssueService _issueService;

        public IActionResult Index()
        {
            return Ok();
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<ActionResult> DeleteStatus(string id, bool safeDelete = false)
        {
            try
            {
                var item = await _taskStatusGetOperations.GetById(id);
                await _taskStatusService.Delete(id, safeDelete);
                var folder = await _folderGetOperations.GetById(item.FolderId);
                int newStatus = folder.StatusesOrder.LastIndexOf(id) - 1;
                if (newStatus < 0) newStatus = 0;
                var issues = await _issueGetOperations.ByStatus(id);
                issues.ToList().ForEach(async x => {
                    await _issueService.ChangeStatus(new Core.Contract.Issue.Dtos.ChangeStatusDto()
                    {
                        IssueId = x.Id,
                        StatusId = folder.StatusesOrder.ElementAt(newStatus)
                    });
                });
                folder.StatusesOrder.Remove(id);
                await _folderWriteOperations.Update(folder.Id, folder);
            }
            catch { }
            return Redirect("/Folder/Folders/" + id);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateStatus(string folderId, string title)
        {
            try
            {
                var status = new CreateStatusDto()
                {
                    FolderId = folderId,
                    Name = title
                };
                var item = await _taskStatusService.Create(status);
                var folder = await _folderGetOperations.GetById(folderId);
                folder.StatusesOrder.Add(item.Id);
                await _folderWriteOperations.Update(folderId, folder);
                return Json(item.Id);
            }
            catch { }
            return Redirect("/Folder/Folders/" + folderId);
        }

        [ActionName("Order")]
        [HttpPost]
        public async Task<ActionResult> OrderStatuses(string folderId, string order)
        {
            try
            {
                List<string> ids = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(order)).Split(',').ToList();
                var folder = await _folderService.ById(folderId);
                folder.StatusesOrder = ids;
                await _folderWriteOperations.Update(folderId, folder);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        public async Task<ActionResult> Update(string folderId)
        {
            var vm = await _constructKanbanCommand.Construct(folderId);
            return PartialView("~/Views/Folder/Desk.cshtml", vm);
        }
    }
}
