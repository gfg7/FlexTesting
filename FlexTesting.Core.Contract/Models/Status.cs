namespace FlexTesting.Core.Contract.Models
{
    public record Status : IModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public string SourceId { get; set; }
        public string FolderId { get; set; }
        public string NextStatusId { get; set; }
        public bool IsDeleted { get; set; }
    }
}