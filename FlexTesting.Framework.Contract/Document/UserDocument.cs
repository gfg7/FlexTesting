using FlexTesting.Framework.Contract.Output;

namespace FlexTesting.Framework.Contract.Document
{
    public record UserDocument : IDocument
    {
        public string Id { get; set; }
        public Info Info { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        // md5 hash + salt
        public string Password { get; set; }
        public string Bio { get; set; }
        public string CurrentToken { get; set; }
        
        //todo: make ignored
        public string Fio => $"{LastName} {FirstName} {MiddleName}";

        public AuthResult ToAuthResult(SignType signType)
        {
            return new AuthResult(Id, Login, CurrentToken, Fio, signType);
        }
    }
}