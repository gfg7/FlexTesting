using System.Collections.Generic;
using FlexTesting.Core.Contract.Issue.Dtos;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.WebApp.Models
{
    public record KanbanViewModel
    {
        public Folder Folder { get; set; }
        public List<Status> StatusList { get; set; } = new();
        public Dictionary<string, List<Issue>> IssuesList { get; set; } = new();
        public CreateIssueDto CreateIssueDto { get; set; } = new ();

        public KanbanViewModel() {}

        public KanbanViewModel(Folder folder, List<Status> statusList,
            Dictionary<string, List<Issue>> issuesList)
            => (Folder, StatusList, IssuesList) = (folder, statusList, issuesList);
    }
}