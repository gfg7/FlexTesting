using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.TaskStatus.Dtos
{
    public record RenameTaskStatusDto
    {
        [Required]
        public string TaskStatusId { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string NewName { get; set; }
    }
}