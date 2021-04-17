using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Database.Operations.Get;
using FlexTesting.Framework.Contract.Database.Operations.Write;
using FlexTesting.Framework.Contract.Document;
using FlexTesting.Framework.Contract.Helpers;
using FlexTesting.Framework.Contract.Input;
using FlexTesting.Framework.Contract.Output;
using FlexTesting.Framework.Contract.Services;

namespace FlexTesting.Framework.Services
{
    public class UserService : IUserService
    {
        private readonly IUserGetDbOperations _userGetDbOperations;
        private readonly IUserWriteDbOperations _userWriteDbOperations;
        
        public async Task<AuthResult> Login(LoginDto loginDto)
        {
            loginDto.ValidationAndThrow();
            var user = await _userGetDbOperations.ByCredentials(loginDto.Login, loginDto.Password);
            if (user is null)
            {
                throw new ValidationException($"Пользователь с логином {loginDto.Login} не найден");
            }
            
            //todo: генерация токена
            var token = "";
            await _userWriteDbOperations.SetToken(user.Id, token);

            return new AuthResult(user.Id, user.Login, token, user.Fio, SignType.Login);
        }

        public async Task<AuthResult> Register(RegisterDto registerDto)
        {
            registerDto.ValidationAndThrow();

            var existingUser = await _userGetDbOperations.ByLogin(registerDto.Login);
            if (existingUser is not null)
            {
                throw new ValidationException("Пользователь уже существует");
            }

            var user = registerDto.MapToDocument();

            var token = "";
            //todo: generate new id
            user.Id = "";
            user.CurrentToken = token;

            await _userWriteDbOperations.Insert(user);
            
            return new AuthResult(user.Id, user.Login, token, user.Fio, SignType.Register);
        }

        public async Task<AuthResult> CurrentUser(string token)
        {
            var user = await _userGetDbOperations.ByToken(token);
            
            return user?.ToAuthResult(SignType.Login);
        }
    }
}