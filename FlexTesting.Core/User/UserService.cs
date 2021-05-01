using System;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Contract.User.Dtos;

namespace FlexTesting.Core.User
{
    public class UserService : IUserService
    {
        private readonly IUserGetOperations _userGetOperations;
        private readonly IUserWriteOperations _userWriteOperations;

        public UserService(IUserGetOperations userGetOperations, 
            IUserWriteOperations userWriteOperations)
        {
            _userGetOperations = userGetOperations;
            _userWriteOperations = userWriteOperations;
        }

        public async Task<Contract.Models.User> Login(LoginDto loginDto)
        {
            ValidationHelper.ValidateAndThrow(loginDto);
            var user = await _userGetOperations.ByUserName(loginDto.Login);
            if (user is null)
            {
                throw new NotFoundException("Пользователь не найден");
            }

            if (!PasswordHelper.ComparePassword(user, loginDto.Password))
            {
                throw new InvalidPasswordException();
            }
            
            var token = Guid.NewGuid().ToString();
            await _userWriteOperations.SetToken(user.Id, token);

            return user;
        }

        public async Task<Contract.Models.User> Register(NewUserDto newUser)
        {
            ValidationHelper.ValidateAndThrow(newUser);
            var existUser = await _userGetOperations.ByUserName(newUser.Login);
            if (existUser is not null)
            {
                throw new ExistingUserException();
            }

            var model = new Contract.Models.User
            {
                Id = Guid.NewGuid().ToString(),
                Bio = newUser.Bio,
                FirstName = newUser.FirstName,
                Login = newUser.Login,
                LastName = newUser.LastName,
                MiddleName = newUser.MiddleName
            };

            var password = PasswordHelper.GeneratePassword(newUser.Password);
            model.Salt = password.Salt;
            model.Password = password.Hash;
            model.Token = Guid.NewGuid().ToString();
            
            return await _userWriteOperations.Create(model);
        }

        public async Task<Contract.Models.User> GetCurrentUser(string token)
        {
            var user = await _userGetOperations.ByToken(token);
            if (user is null)
            {
                throw new NotFoundException("Пользователь не найден");
            }

            return user;
        }

        public async Task<Contract.Models.User> DeleteUser(string id, bool safeDelete = true)
        {
            if (!await _userGetOperations.ExistsById(id))
            {
                throw new NotFoundException("Пользователь не найден");
            }

            return safeDelete 
                ? await _userWriteOperations.SafeDelete(id) 
                : await _userWriteOperations.Delete(id);
        }

        public async Task<Contract.Models.User> SetFio(UserChangeFioDto changeFioDto)
        {
            ValidationHelper.ValidateAndThrow(changeFioDto);
            if (!await _userGetOperations.ExistsById(changeFioDto.UserId))
            {
                throw new NotFoundException("Пользователь не найден");
            }
            return await _userWriteOperations.UpdateFio(
                changeFioDto.UserId,
                changeFioDto.FirstName,
                changeFioDto.LastName,
                changeFioDto.MiddleName
                );
        }

        public async Task<Contract.Models.User> ChangePassword(UserChangePasswordDto changePasswordDto)
        {
            ValidationHelper.ValidateAndThrow(changePasswordDto);
            
            var user = await _userGetOperations.GetById(changePasswordDto.UserId);
            if (user is null)
            {
                throw new NotFoundException("Пользователь не найден");
            }
            if(!PasswordHelper.ComparePassword(user, changePasswordDto.OldPassword))
            {
                throw new InvalidPasswordException();
            }

            var (hash, salt) = PasswordHelper.GeneratePassword(changePasswordDto.NewPassword);
            return await _userWriteOperations.UpdatePassword(user.Id, hash, salt);
        }

        public async Task<Contract.Models.User> UnsetToken(string userId)
        {
            return await _userWriteOperations.UnsetToken(userId);
        }
    }
}