﻿namespace FlexTesting.Framework.Document
{
    public class TestCaseDocument : IDocument
    {
        public string Id { get; set; }
        public Info Info { get; set; }
        public string Text { get; set; }
        public bool IsCancelled { get; set; }
        public TestDocument[] TestDocuments { get; set; } 
    }
}