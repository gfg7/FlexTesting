using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.User.Dtos
{
    public record NewUserDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилия обязательна")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Логин обязателен")]
        public string Login { get; set; }
        public string Bio { get; set; }
        [Required(ErrorMessage = "Пароль обязателен")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        public string Email { get; set; }
    }
}