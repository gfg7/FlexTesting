using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Database.Operations.Get;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Operations
{
    public class TestGetDbOperations : ITestBagGetDbOperations
    {
        public async Task<TestBagDocument> ById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TestBagDocument>> ByIds(params string[] ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TestBagDocument>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public string ByUserId(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}