using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Folder;
using FlexTesting.Core.Issue;
using FlexTesting.Core.Source;
using FlexTesting.Core.TaskStatus;
using FlexTesting.Core.Token;
using FlexTesting.Core.User;
using MongoDB.Driver;

namespace FlexTesting.Core.Database
{
    public class DbContext : IFolderContext, IIssueContext, IStatusContext, ITokenContext, IUserContext, ISourceContext
    {
        private static IFolderContext _folderContext;
        private static IIssueContext _issueContext;
        private static IStatusContext _statusContext;
        private static ITokenContext _tokenContext;
        private static IUserContext _userContext;
        private static ISourceContext _sourceContext;

        public static IFolderContext FolderContext => _folderContext ??= new DbContext();
        public static IIssueContext IssueContext => _issueContext ??= new DbContext();
        public static IStatusContext StatusContext => _statusContext ??= new DbContext();
        public static ITokenContext TokenContext => _tokenContext ??= new DbContext();
        public static IUserContext UserContext => _userContext ??= new DbContext();
        public static ISourceContext SourceContext => _sourceContext ??= new DbContext();

        public IMongoDatabase Database { get; }
        public DbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            Database = client.GetDatabase("FlexTesting");
        }

        public IMongoCollection<Contract.Models.Folder> Folders => Database.GetCollection<Contract.Models.Folder>(nameof(Folders));
        public IMongoCollection<Contract.Models.Issue> Issues => Database.GetCollection<Contract.Models.Issue>(nameof(Issues));
        public IMongoCollection<Status> Statuses => Database.GetCollection<Contract.Models.Status>(nameof(Statuses));
        public IMongoCollection<Contract.Models.Token> Tokens => Database.GetCollection<Contract.Models.Token>(nameof(Tokens));
        public IMongoCollection<Contract.Models.User> Users => Database.GetCollection<Contract.Models.User>(nameof(Users));
        public IMongoCollection<Contract.Models.Source> Sources => Database.GetCollection<Contract.Models.Source>(nameof(Sources));
    }
}