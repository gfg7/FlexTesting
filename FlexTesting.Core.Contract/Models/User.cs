namespace FlexTesting.Core.Contract.Models
{
    public class User : IModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Bio { get; set; }
    }
}