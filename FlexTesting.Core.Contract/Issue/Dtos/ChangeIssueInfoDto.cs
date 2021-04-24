namespace FlexTesting.Core.Contract.Issue.Dtos
{
    public record ChangeIssueInfoDto
    {
        public string IssueId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}