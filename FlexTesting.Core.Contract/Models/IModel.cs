namespace FlexTesting.Core.Contract.Models
{
    public interface IModel
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}