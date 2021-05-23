using System;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Contract.User.Dtos;
using HarabaSourceGenerators.Common.Attributes;
using MailKit.Net.Smtp;
using MimeKit;

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

        public async Task SendEmailConfirmMessage(Contract.Models.User user)
        {
            var emailMessage = new MimeMessage();

            var token = await GenerateTokenForUser(user.Id);
            var url = UrlHelper.CurrentUrl + $"/account/confirm/{token}";
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "dmitrybahtenkov@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(user.FirstName, user.Email));
            emailMessage.Subject = "Подтверждение email";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<h1>Здравствуйте, {user.LastName} {user.FirstName}</h1>" +
                       $"<p>Спешим вам сообщить, что вы регистрировались в программе FlexTesting</p>" +
                    $"<p>И теперь вам необходимо подтвердить email. Для это перейдите по <a href=\"{url}\">ссылке</a></p>"
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.mail.ru", 2525, true);
            await client.AuthenticateAsync("flextesting@mail.ru", "AdoRtRYtp11^");
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);
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