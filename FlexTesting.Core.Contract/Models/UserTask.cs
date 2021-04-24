namespace FlexTesting.Core.Contract.Models
{
    public record UserTask : IModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string SourceId { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusId { get; set; }
    }
}