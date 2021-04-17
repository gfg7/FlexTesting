using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Database.Operations.Write;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Operations
{
    public class TestWriteDbOperations : ITestBagWriteDbOperations
    {
        public async Task<TestBagDocument> Insert(TestBagDocument item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TestBagDocument> Upsert(TestBagDocument item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TestBagDocument> Update()
        {
            throw new System.NotImplementedException();
        }

        public async Task<TestBagDocument> SafeDelete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TestBagDocument> UnsafeDelete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}