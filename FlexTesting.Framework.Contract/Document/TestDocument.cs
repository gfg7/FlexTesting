using FlexTesting.Framework.Contract.Document.Enums;

namespace FlexTesting.Framework.Contract.Document
{
    public class TestDocument : IDocument
    {
        public string Id { get; set; }
        public Info Info { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public TestState State { get; set; } 
    }
}