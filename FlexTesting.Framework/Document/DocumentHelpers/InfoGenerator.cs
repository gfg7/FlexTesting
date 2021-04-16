using System;

namespace FlexTesting.Framework.Document.DocumentHelpers
{
    public static class InfoGenerator
    {
        public static Info GenerateInfo(string currentUserId)
        {
            return new Info
            {
                CreatedAt = DateTime.UtcNow,
                CreatedById = !string.IsNullOrEmpty(currentUserId) ? currentUserId : "Not authorized entity create",
                DeletedAt = null,
                IsDeleted = false
            };
        }

        public static Info MarkIsDeleted(Info info)
        {
            return info with
            {
                IsDeleted = true,
                DeletedAt = DateTime.UtcNow
            };
        }
    }
}