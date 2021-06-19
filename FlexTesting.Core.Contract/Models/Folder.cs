using System.Collections.Generic;

namespace FlexTesting.Core.Contract.Models
{
    public record Folder : IModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<string> InvitedUsers { get; set; } = new();
        public string Name { get; set; }
        public List<string> StatusesOrder { get; set; } = new();
        public bool IsDeleted { get; set; }
    }
}