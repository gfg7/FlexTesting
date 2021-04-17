namespace FlexTesting.Framework.Contract.Output
{
    public record AuthResult(
        string UserId, 
        string Login,
        string CurrentToken,
        string Fio,
        SignType SignType)
    {
        public bool IsSuccess => !string.IsNullOrEmpty(CurrentToken); 
    }

    public enum SignType
    {
        Login,
        Register
    }
}