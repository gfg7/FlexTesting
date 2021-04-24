namespace FlexTesting.Core.Contract.Issue.Dtos
{
    public record ChangeStatusDto
    {
        public string IssueId { get; set; }
        public string StatusId { get; set; }
    }
}