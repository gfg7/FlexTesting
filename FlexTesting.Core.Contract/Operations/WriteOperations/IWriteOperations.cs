using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Core.Contract.Operations.WriteOperations
{
    public interface IWriteOperations<TModel> where TModel : IModel
    {
        public Task<TModel> Create(TModel item);
        public Task<TModel> UpdateOne(string id, TModel item);
        public Task Delete(string id);
    }
}