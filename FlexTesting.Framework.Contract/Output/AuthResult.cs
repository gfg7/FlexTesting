namespace FlexTesting.Framework.Contract.Output
{
    public record AuthResult
    {
        public bool IsSuccess => !string.IsNullOrEmpty(CurrentToken); 
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CurrentToken { get; set; }
        public string Fio { get; set; }
        public SignType SignType { get; set; }
    }

    public enum SignType
    {
        Login,
        Register
    }
}