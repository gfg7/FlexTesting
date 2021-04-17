namespace FlexTesting.Framework.Contract.Document
{
    public class BugDocument : IDocument
    {
        public string Id { get; set; }
        public Info Info { get; set; }
        public string TestBagId { get; set; }
        public string Description { get; set; }
        
    }
}