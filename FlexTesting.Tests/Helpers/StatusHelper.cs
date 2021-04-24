using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.Source;

namespace FlexTesting.Tests.Helpers
{
    public static class StatusHelper
    {
        public static TaskStatus ValidStatus => new()
        {
            Name = "Todo",
            Id = "validstatus",
            SourceId = SourceIds.Flex.ToString(),
            FolderId = FolderHelper.ValidFolder.Id
        };

        public static TaskStatus DeletionStatus => new()
        {
            Name = "Del",
            Id = "delstatus",
            SourceId = SourceIds.Flex.ToString(),
            FolderId = FolderHelper.ValidFolder.Id
        };
        
        public static TaskStatus ForFolderStatus => new()
        {
            Name = "Folder",
            Id = "FolderStat",
            SourceId = SourceIds.Flex.ToString(),
            FolderId = FolderHelper.FolderForDeletion.Id
        };
    }
}