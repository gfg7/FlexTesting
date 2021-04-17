using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Framework.Contract.Input
{
    public record RegisterDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилия обязательна")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Логин обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обязателен")]
        public string Password { get; set; }
        public string Bio { get; set; }
    }
}