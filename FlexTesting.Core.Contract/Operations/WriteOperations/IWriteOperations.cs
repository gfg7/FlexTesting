using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Core.Contract.Operations.WriteOperations
{
    public interface IWriteOperations<TModel> where TModel : IModel
    {
        public Task<TModel> Create(TModel item);
        public Task<TModel> Update(string id, TModel item);
        public Task<TModel> Delete(string id);
        public Task<TModel> SafeDelete(string id);
    }
}