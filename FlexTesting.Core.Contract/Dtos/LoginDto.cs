using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.Dtos
{
    public record LoginDto
    {
        public LoginDto(string password, string login)
        {
            Password = password;
            Login = login;
        }

        [Required(ErrorMessage = "Введите логин", AllowEmptyStrings = false)]
        public string Login { get; init; } 
        [Required(ErrorMessage = "Введите пароль", AllowEmptyStrings = false)]
        public string Password { get; init; } 

    }
}