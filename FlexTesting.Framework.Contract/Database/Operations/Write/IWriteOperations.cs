using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Contract.Database.Operations.Write
{
    public interface IWriteOperations<TDocument> where TDocument : IDocument
    {
        public Task<TDocument> Insert(TDocument item);
        public Task<TDocument> Upsert(TDocument item);
        public Task<TDocument> Update(/*Допилить когда будет инет :)*/);
        public Task<TDocument> SafeDelete(string id);
        public Task<TDocument> UnsafeDelete(string id);
    }
}