using MongoDB.Driver;

namespace FlexTesting.Core.Issue
{
    public interface IIssueContext
    {
        public IMongoCollection<Contract.Models.Issue> Issues { get; }
    }
}