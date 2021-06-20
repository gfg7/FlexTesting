using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Tests.Mocks.IssueMocks
{
    public class IssueWriteOperationsMock : IIssueWriteOperations
    {
        public async Task<Issue> Create(Issue item)
        {
            Entities.Issues.Add(item);
            return item;
        }

        public async Task<Issue> Update(string id, Issue item)
        {
            Entities.Issues.RemoveAll(x=>x.Id == id);
            Entities.Issues.Add(item);
            return item;
        }

        public async Task<Issue> Delete(string id)
        {
            var item = Entities.Issues.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            Entities.Issues.RemoveAll(x => x.Id == id);
            return item;
        }

        public async Task<Issue> SafeDelete(string id)
        {
            var item = Entities.Issues.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (item is not null)
            {
                item.IsDeleted = true;
            }

            return item;
        }

        public async Task<Issue> UpdateName(string issueId, string name)
        {
            var item = Entities.Issues.FirstOrDefault(x => x.Id == issueId && !x.IsDeleted);
            if (item is not null)
            {
                item.Name = name;
            }

            return item;
        }

        public async Task<Issue> UpdateDescription(string issueId, string description)
        {
            var item = Entities.Issues.FirstOrDefault(x => x.Id == issueId && !x.IsDeleted);
            if (item is not null)
            {
                item.Name = description;
            }

            return item;
        }

        public async Task<Issue> UpdateFolder(string issueId, string folderId)
        {
            var item = Entities.Issues.FirstOrDefault(x => x.Id == issueId && !x.IsDeleted);
            if (item is not null)
            {
                item.FolderId = folderId;
            }

            return item;
        }

        public async Task DeleteByFolder(string folderId)
        {
            Entities.Issues.RemoveAll(x => x.FolderId == folderId);
        }

        public async Task<Issue> UpdateStatus(string issueId, string statusId)
        {
            var item = Entities.Issues.FirstOrDefault(x => x.Id == issueId && !x.IsDeleted);
            if (item is not null)
            {
                item.StatusId = statusId;
            }

            return item;
        }
    }
}