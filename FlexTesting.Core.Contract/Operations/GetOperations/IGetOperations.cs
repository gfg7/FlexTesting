using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Core.Contract.Operations.GetOperations
{
    public interface IGetOperations<TModel> where TModel : IModel
    {
        public Task<TModel> GetById(string id);
        public Task<IEnumerable<TModel>> GetAll(string id);
        public Task<bool> ExistsById(string id);
    }
}