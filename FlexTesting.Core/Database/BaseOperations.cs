using FlexTesting.Core.Contract.Models;
using MongoDB.Driver;

namespace FlexTesting.Core.Database
{
    public abstract class BaseOperations<TModel> where TModel : IModel
    {
        protected FilterDefinitionBuilder<TModel> F => Builders<TModel>.Filter;
        protected UpdateDefinitionBuilder<TModel> U => Builders<TModel>.Update;

        protected readonly DbContext DbContext;
        protected readonly IMongoCollection<TModel> Collection;
        
        protected BaseOperations(DbContext dbContext)
        {
            DbContext = dbContext;
            Collection = DbContext.Database.GetCollection<TModel>(typeof(TModel).Name);
        }
    }
}