using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.Source;

namespace FlexTesting.Tests.Mocks.SourceMocks
{
    public class SourceGetOperationsMock : ISourceGetOperations
    {
        public async Task<Source> GetById(string id)
        {
            return Entities.Sources.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Source>> GetAll(string id)
        {
            return Entities.Sources;
        }

        public async Task<bool> ExistsById(string id)
        {
            return Entities.Sources.Exists(x => x.Id == id);
        }

        public async Task<Source> ByName(string name)
        {
            return Entities.Sources.FirstOrDefault(x => x.Name == name);
        }
    }
}