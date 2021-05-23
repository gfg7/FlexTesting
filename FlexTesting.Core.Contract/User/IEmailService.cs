using System.Threading.Tasks;
using FlexTesting.Core.Contract.User.Dtos;

namespace FlexTesting.Core.Contract.User
{
    public interface IEmailService
    {
        public Task<Models.User> ConfirmEmail(EmailDto dto);
        public Task<Models.User> SendEmailConfirmMessage(Contract.Models.User user, string baseUrl);
        public Task<string> GenerateTokenForUser(string userId);
    }
}