namespace FlexTesting.Core.Contract.Folder.Dtos
{
    public record RenameFolderDto
    {
        public string FolderId { get; set; }
        public string NewName { get; set; }
    }
}