using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Dtos;

namespace FlexTesting.Core.Contract.User
{
    public interface IUserService
    {
        public Task<Models.User> Login(LoginDto loginDto);
        public Task<Models.User> Register(NewUserDto newUser);
        public Task<Models.User> GetCurrentUser(string token);
        public Task<Models.User> DeleteUser(string id);
        public Task<Models.User> SetFio(UserChangeFioDto changeFioDto);
        public Task<Models.User> ChangePassword(UserChangePasswordDto changePasswordDto);
    }
}