namespace FlexTesting.Core.Contract.Dtos
{
    public record CurrentUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public string Fio => $"{LastName} {FirstName} {MiddleName}";
        
    }
}