namespace FlexTesting.Core.Contract.Models
{
    public class Issue : IModel
    {
        public string Id { get; set; }
        public string FolderId { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusId { get; set; }
    }
}