﻿using FlexTesting.Framework.Contract.Document.Enums;

namespace FlexTesting.Framework.Contract.Document
{
    public class StateDocument : IDocument
    {
        public string Id { get; set; }
        public Info Info { get; set; }
        public string Name { get; set; }
        public string Board { get; set; }
        public string UserId { get; set; }
        public Group Group { get; set; }
        public TaskSource Source { get; set; }
    }
}