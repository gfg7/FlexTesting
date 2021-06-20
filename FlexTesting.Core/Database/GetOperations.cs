using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.Operations.GetOperations;
using MongoDB.Driver;

namespace FlexTesting.Core.Database
{
    public abstract class GetOperations<TModel> : BaseOperations<TModel>, IGetOperations<TModel> where TModel : IModel
    {
        protected GetOperations(DbContext dbContext) : base(dbContext)
        {
        }


        public async Task<TModel> GetById(string id)
        {
            return await GetOne(F.Eq(x => x.Id, id));
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            return await GetList(FilterDefinition<TModel>.Empty);
        }

        public async Task<bool> ExistsById(string id)
        {
            return await Collection.CountDocumentsAsync(F.Eq(x => x.Id, id)) > 0;
        }
        
        protected async Task<List<TModel>> GetList(FilterDefinition<TModel> filterDefinition)
        {
            return await (await Collection.FindAsync(filterDefinition)).ToListAsync();
        }

        protected async Task<TModel> GetOne(FilterDefinition<TModel> filterDefinition)
        {
            return await (await Collection.FindAsync(filterDefinition)).FirstOrDefaultAsync();
        }
    }
}