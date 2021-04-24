using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.Dtos
{
    public record UserChangePasswordDto
    {
        [Required()]
        public string UserId { get; init; }
        [Required(ErrorMessage = "Введите старый пароль")]
        public string OldPassword { get; init; }
        [Required(ErrorMessage = "Введите новый пароль")]
        public string NewPassword { get; init; }
    }
}