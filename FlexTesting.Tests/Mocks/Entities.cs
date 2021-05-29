using System.Collections.Generic;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Tests.Helpers;

namespace FlexTesting.Tests.Mocks
{
    public static class Entities
    {
        static Entities()
        {
            UsersList = new List<User>
            {
                UserHelper.UserModel,
                UserHelper.OtherUserModel,
                UserHelper.DeletingUserModel,
                UserHelper.UserModelWithNoConfirm
            };

            Sources = new List<Source>
            {
                Core.Contract.Source.Sources.SpaceSource,
                Core.Contract.Source.Sources.TrelloSource,
                Core.Contract.Source.Sources.FlexSource,
            };

            Tokens = new List<Token>
            {
                TokenHelper.ValidToken,
                TokenHelper.DeletionToken
            };

            Folders = new List<Folder>
            {
                FolderHelper.ValidFolder,
                FolderHelper.FolderForDeletion
            };

            Statuses = new List<Status>
            {
                StatusHelper.DeletionStatus,
                StatusHelper.ValidStatus,
                StatusHelper.ForFolderStatus
            };

            Issues = new List<Issue>
            {
                IssueHelper.ValidIssue,
                IssueHelper.IssueForDeletion
            };
            
        }
        public static List<User> UsersList { get; set; }
        public static List<Token> Tokens { get; set; }
        public static List<Source> Sources { get; set; }
        public static List<Folder> Folders { get; set; }
        public static List<Status> Statuses { get; set; }
        public static List<Issue> Issues { get; set; }
    }
}