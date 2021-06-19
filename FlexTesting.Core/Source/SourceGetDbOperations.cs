using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Source;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.Source
{
    public class SourceGetDbOperations : ISourceGetOperations
    {
        private readonly ISourceContext _sourceContext;

        public SourceGetDbOperations()
        {
            _sourceContext = DbContext.SourceContext;
        }

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
            var filter = Builders<Contract.Models.Source>.Filter.Eq(x => x.Id, id);
            return await _sourceContext.Sources.CountDocumentsAsync(filter) != 0;
        }

        public async Task<Contract.Models.Source> ByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}