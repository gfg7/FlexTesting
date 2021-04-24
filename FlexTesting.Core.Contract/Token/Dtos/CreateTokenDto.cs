using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.Token
{
    public record CreateTokenDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string SourceId { get; set; }
        [Required]
        public string Payload { get; set; }
    }
}