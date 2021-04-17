namespace FlexTesting.Framework.Contract.Document
{
    public class ExternalAccount<TAccount> : IDocument where TAccount : IExternalAccount
    {
        public string Id { get; set; }
        public Info Info { get; set; }
        public string UserId { get; set; }
        public TAccount Account { get; set; }
    }
}