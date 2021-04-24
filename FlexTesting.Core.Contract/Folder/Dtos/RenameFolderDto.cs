using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.Folder.Dtos
{
    public record RenameFolderDto
    {
        [Required]
        public string FolderId { get; set; }
        [Required(ErrorMessage = "Введите новое имя")]
        public string NewName { get; set; }
    }
}