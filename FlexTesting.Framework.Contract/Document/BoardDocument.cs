namespace FlexTesting.Framework.Contract.Document
{
    public record BoardDocument : IDocument
    {
        public string Id { get; set; }
        public Info Info { get; set; }
        public string Name { get; set; }
        public string[] StateIds { get; set; }
    }
}