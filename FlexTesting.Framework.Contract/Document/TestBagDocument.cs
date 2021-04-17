namespace FlexTesting.Framework.Contract.Document
{
    public class TestBagDocument : IDocument
    {
        public string Id { get; set; }
        public Info Info { get; set; }
        public string TaskId { get; set; }
        public string Text { get; set; }
        public bool IsCancelled { get; set; }
        public TestCaseDocument[] TestCaseDocuments { get; set; }
    }
}