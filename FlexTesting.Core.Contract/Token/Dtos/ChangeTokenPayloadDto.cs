using System.ComponentModel.DataAnnotations;

namespace FlexTesting.Core.Contract.Token.Dtos
{
    public class ChangeTokenPayloadDto
    {
        [Required]
        public string TokenId { get; set; }
        [Required]
        public string Payload { get; set; }
    }
}