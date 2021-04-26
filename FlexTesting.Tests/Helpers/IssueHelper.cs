using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Tests.Helpers
{
    public static class IssueHelper
    {
        public static Issue ValidIssue => new()
        {
            Id = "validissueid",
            Name = "Name of valid issue",
            Description = "Description for valid issue",
            FolderId = FolderHelper.ValidFolder.Id,
            StatusId = StatusHelper.ValidStatus.Id
        };
        
        public static Issue IssueForDeletion => new()
        {
            Id = "delissueid",
            Name = "Name of del issue",
            Description = "Description for del issue",
            FolderId = FolderHelper.FolderForDeletion.Id,
            StatusId = StatusHelper.DeletionStatus.Id
        };
    }
}