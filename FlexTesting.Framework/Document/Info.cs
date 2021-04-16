using System;

namespace FlexTesting.Framework.Document
{
    public class Info
    {
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}