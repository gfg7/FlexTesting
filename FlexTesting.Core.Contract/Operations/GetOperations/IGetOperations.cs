using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexTesting.Core.Contract.Operations.GetOperations
{
    public interface IGetOperations<TModel>
    {
        public Task<TModel> GetById(string id);
        public Task<IEnumerable<TModel>> GetAll(string id);
    }
}