using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.WebApp.Models;
using HarabaSourceGenerators.Common.Attributes;

namespace FlexTesting.WebApp.Commands
{
    [Inject]
    public partial class ConstructKanbanCommand
    {
        private readonly IFolderService _folderService;
        private readonly ITaskStatusService _taskStatusService;
        private readonly IIssueService _issueService;

        public async Task<KanbanViewModel> Construct(string folderId)
        {
            var folder = await _folderService.ById(folderId);
            var statuses = await _taskStatusService.GetByFolder(folderId);
            var orderedStatuses = new List<Status>();
            folder.StatusesOrder.ForEach(x => orderedStatuses.Add(statuses.Where(s => s.Id == x)?.First()));
            var issues = await _issueService.ByFolder(folderId);
            return new KanbanViewModel(folder, orderedStatuses, issues);
        }
    }
}