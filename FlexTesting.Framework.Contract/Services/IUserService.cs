using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Input;
using FlexTesting.Framework.Contract.Output;

namespace FlexTesting.Framework.Contract.Services
{
    public interface IUserService
    {
        public Task<AuthResult> Login(LoginDto loginDto);
        public Task<AuthResult> Register(RegisterDto registerDto);
        public Task<AuthResult> CurrentUser(string token);
    }
}