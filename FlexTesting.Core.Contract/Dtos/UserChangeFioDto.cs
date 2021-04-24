using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.Dtos
{
    public record UserChangeFioDto
    {
        [Required]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}