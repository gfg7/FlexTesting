namespace FlexTesting.Core.Contract.User.Dtos
{
    public record EmailDto
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}