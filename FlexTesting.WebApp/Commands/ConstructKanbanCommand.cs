using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
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

        public async Task<KanbanViewModel> Construct(string folderId)
        {
            var folder = await _folderService.ById(folderId);
            var statuses = await _taskStatusService.GetByFolder(folderId);
            return new KanbanViewModel(folder, statuses.ToList());
        }
    }
}