using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Contract.Issue.Dtos;
using FlexTesting.WebApp.Models;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace FlexTesting.WebApp.Controllers
{
    [Inject]
    public partial class IssueController : Controller
    {
        private readonly IIssueService _issueService;

        public async Task<IActionResult> Info(string id)
        {
            try
            {
                var issue = await _issueService.ById(id);
                return View(issue);
            }
            catch (BusinessException e)
            {
                return View("Error", ErrorViewModel.WithError(e.Message));
            }
        }

        [HttpPost("Create/{id}")]
        public async Task<IActionResult> Create(string id, KanbanViewModel dto)
        {
            dto.CreateIssueDto.FolderId = id;
            try
            {
                var issue = await _issueService.Create(dto.CreateIssueDto);
                return Redirect($"/Issue/Info/{issue.Id}");
            }
            catch(BusinessException e)
            {
                return View("Error", ErrorViewModel.WithError(e.Message));
            }
        }

        [HttpPost()]
        public async Task<IActionResult> ChangeStatus([FromQuery] string statusId,[FromQuery] string issueId)
        {
            var issue = await _issueService.ById(issueId);
            try
            {
                var result = await _issueService.ChangeStatus(new ChangeStatusDto
                    {IssueId = issueId, StatusId = statusId});
                return Redirect($"/Folder/Folders/{issue.FolderId}");
            }
            catch
            {
                return Redirect($"/Folder/Folders/{issue.FolderId}");
            }
        }
    }
}