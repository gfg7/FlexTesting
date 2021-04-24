using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.Issue.Dtos
{
    public class CreateIssueDto
    {
        [Required(ErrorMessage = "Название задачи обязательно")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Текст задачи обязателен")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Статус задачи обзателен")]
        public string StatusId { get; set; }
        [Required(ErrorMessage = "Директория обязательна")]
        public string FolderId { get; set; }
        public string ExternalId { get; set; }
    }
}