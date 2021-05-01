using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.User.Dtos
{
    public record LoginDto
    {
        public LoginDto(string password, string login)
        {
            Password = password;
            Login = login;
        }
        
        public LoginDto(){}

        [Required(ErrorMessage = "Введите логин", AllowEmptyStrings = false)]
        public string Login { get; set; } 
        [Required(ErrorMessage = "Введите пароль", AllowEmptyStrings = false)]
        public string Password { get; set; } 

    }
}