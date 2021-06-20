using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Source;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.Source
{
    public class SourceGetDbOperations : GetOperations<Contract.Models.Source>, ISourceGetOperations
    {
        public async Task<Contract.Models.Source> ByName(string name)
        {
            return await GetOne(F.Eq(x => x.Name, name));
        }

        public SourceGetDbOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}