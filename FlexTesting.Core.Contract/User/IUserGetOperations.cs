using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.GetOperations;

namespace FlexTesting.Core.Contract.User
{
    public interface IUserGetOperations : IGetOperations<Models.User>
    {
        public Task<Models.User> ByUserName(string userName);
        public Task<Models.User> ByToken(string token);
    }
}