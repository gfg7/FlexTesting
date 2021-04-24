﻿namespace FlexTesting.Core.Contract.Models
{
    public record Folder : IModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}