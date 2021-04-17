using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Contract.Database.Operations.Get
{
    public interface ITestBagGetDbOperations : IGetOperations<TestBagDocument>
    {
        public Task<TestBagDocument> ByUserId(string userId);
    }
}