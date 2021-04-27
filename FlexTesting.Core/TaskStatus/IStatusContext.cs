using FlexTesting.Core.Contract.Models;
using MongoDB.Driver;

namespace FlexTesting.Core.TaskStatus
{
    public interface IStatusContext
    {
        public IMongoCollection<Status> Statuses { get; }
    }
}