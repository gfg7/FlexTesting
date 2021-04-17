using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Contract.Services
{
    public interface ITestService
    {
        public Task<TestBagDocument> CreateTestBug(TestBagDocument document);
        public Task<TestBagDocument> GetByUserId(string userId);
        public Task<TestBagDocument> Update(TestBagDocument document);
    }
}