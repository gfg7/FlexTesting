using System;

namespace FlexTesting.Framework.Document
{
    public record Info
    {
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}