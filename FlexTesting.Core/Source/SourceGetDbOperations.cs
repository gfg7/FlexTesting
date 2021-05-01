using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Source;

namespace FlexTesting.Core.Source
{
    public class SourceGetDbOperations : ISourceGetOperations
    {
        public async Task<Contract.Models.Source> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Contract.Models.Source>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ExistsById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.Source> ByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}