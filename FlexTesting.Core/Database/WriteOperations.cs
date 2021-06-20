using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.Operations.WriteOperations;
using MongoDB.Driver;

namespace FlexTesting.Core.Database
{
    public abstract class WriteOperations<TModel> : BaseOperations<TModel>, IWriteOperations<TModel> where TModel : IModel
    {
        protected WriteOperations(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TModel> Create(TModel item)
        {
            await Collection.InsertOneAsync(item);
            return item;
        }

        public async Task<TModel> Update(string id, TModel item)
        {
            var result = await Collection.ReplaceOneAsync(F.Eq(x => x.Id, item.Id), item);
            return result.IsAcknowledged ? item : default;
        }

        public async Task<TModel> Delete(string id)
        {
            var item = await Collection.FindOneAndDeleteAsync(F.Eq(x => x.Id, id));
            return item;
        }

        public async Task<TModel> SafeDelete(string id)
        {
            return await UpdateOne(F.Eq(x=>x.Id, id), U.Set(x => x.IsDeleted, true));
        }

        protected async Task<TModel> UpdateOne(FilterDefinition<TModel> filterDefinition,UpdateDefinition<TModel> updateDefinition)
        {
            var result = await Collection.UpdateOneAsync(filterDefinition, updateDefinition);
            if (result.IsAcknowledged)
            {
                return await (await Collection.FindAsync(filterDefinition)).FirstOrDefaultAsync();
            }

            return default;
        }
    }
}