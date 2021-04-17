namespace FlexTesting.Framework.Contract.Document
{
    public interface IExternalAccount
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}