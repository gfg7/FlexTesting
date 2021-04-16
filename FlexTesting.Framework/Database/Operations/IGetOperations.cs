using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Framework.Document;

namespace FlexTesting.Framework.Database.Operations
{
    public interface IGetOperations<TDocument> where TDocument : IDocument
    {
        public Task<TDocument> ById(string id);
        public Task<IEnumerable<TDocument>> ByIds(params string[] ids);
        public Task<IEnumerable<TDocument>> GetAll();
    }
}