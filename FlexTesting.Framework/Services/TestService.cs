using System;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Database.Operations.Get;
using FlexTesting.Framework.Contract.Database.Operations.Write;
using FlexTesting.Framework.Contract.Document;
using FlexTesting.Framework.Contract.Document.Enums;
using FlexTesting.Framework.Contract.Input;
using FlexTesting.Framework.Contract.Services;

namespace FlexTesting.Framework.Services
{
    public class TestService : ITestService
    {
        private readonly ITestBagGetDbOperations _testBagGetDbOperations;
        private readonly ITestBagWriteDbOperations _testBagWriteDbOperations;
        
        public async Task<TestBagDocument> CreateTestBug(TestBagDocument document)
        {
            //todo: generate id
            return await _testBagWriteDbOperations.Insert(document);
        }

        public async Task<TestBagDocument> GetByUserId(string userId)
        {
            return await _testBagGetDbOperations.ByUserId(userId);
        }

        public async Task<TestBagDocument> Update(TestBagDocument document)
        {
            if (OnUpdated != null) await OnUpdated?.Invoke(document, EventArgs.Empty);
            return await _testBagWriteDbOperations.Upsert(document);
        }

        public event OnUpdatedTest OnUpdated = async (sender, args) =>
        {
            var document = sender as TestBagDocument;

            
            if (document.TestCaseDocuments.All(doc => doc.IsCancelled))
            {
                document.IsCancelled = true;
            }

            foreach (var testCase in document.TestCaseDocuments)
            {
                if (testCase.TestDocuments.All(test => test.State == TestState.Ok))
                {
                    testCase.IsCancelled = true;
                }
            }
        };
    }
}