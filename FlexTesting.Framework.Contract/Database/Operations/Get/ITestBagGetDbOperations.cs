using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Contract.Database.Operations.Get
{
    public interface ITestBagGetDbOperations : IGetOperations<TestBagDocument>
    {
        public string ByUserId(string userId);
    }
}