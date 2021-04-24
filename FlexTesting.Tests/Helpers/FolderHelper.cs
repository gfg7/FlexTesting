using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Tests.Helpers
{
    public class FolderHelper
    {
        public static Folder ValidFolder => new()
        {
            Id = "FolderId",
            Name = "Folder",
            UserId = UserHelper.UserModel.Id
        };

        public static Folder FolderForDeletion => new()
        {
            Id = "FolderForDel",
            Name = "Del",
            UserId = UserHelper.DeletingUserModel.Id
        };
    }
}