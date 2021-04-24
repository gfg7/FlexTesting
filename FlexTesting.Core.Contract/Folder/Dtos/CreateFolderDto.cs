using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.Folder.Dtos
{
    public record CreateFolderDto
    {
        [Required(ErrorMessage = "Введите название директории")]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}