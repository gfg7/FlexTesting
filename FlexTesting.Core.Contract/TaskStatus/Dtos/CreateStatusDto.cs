using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FlexTesting.Core.Contract.TaskStatus.Dtos
{
    public record CreateStatusDto
    {
        [Required(ErrorMessage = "Название обязательно")]
        public string Name { get; set; }
        public string ExternalId { get; set; }
        [Required(ErrorMessage = "Директория обязательна")]
        public string FolderId { get; set; }
        public string SourceId { get; set; }
    }
}