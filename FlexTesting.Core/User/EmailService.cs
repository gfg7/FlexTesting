using System;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Contract.User.Dtos;
using HarabaSourceGenerators.Common.Attributes;

namespace FlexTesting.Core.User
{
    [Inject]
    public partial class EmailService : IEmailService
    {
        private readonly IUserGetOperations _userGetOperations;
        private readonly IUserWriteOperations _userWriteOperations;

        public async Task<Contract.Models.User> ConfirmEmail(EmailDto dto)
        {
            var user = await _userGetOperations.GetById(dto.UserId);
            if (user is null)
            {
                throw new NotFoundException("Пользователь не найден");
            }

            if (user.EmailCode != dto.Code)
            {
                throw new BusinessException("Некорректная ссылка подтверждения");
            }

            return await _userWriteOperations.ConfirmEmail(dto.UserId);
        }

        public Task SendEmailConfirmMessage(NewUserDto dto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GenerateTokenForUser(string userId)
        {
            var token = RandomHelper.GenerateRandomString();
            var user = await _userWriteOperations.SetEmailCode(userId,token);
            if (user is null)
            {
                throw new NotFoundException("Ошибка при создании токена");
            }

            return token;
        }
    }
}