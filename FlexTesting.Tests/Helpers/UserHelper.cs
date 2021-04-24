using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.User.Dtos;

namespace FlexTesting.Tests.Helpers
{
    public class UserHelper
    {
        public static LoginDto LoginDto => new("ahah_12_sasas", "AndrewDaw");
        public static User UserModel => new()
        {
            Id = "qwertyu",
            FirstName = "Andrew",
            LastName = "Daw",
            MiddleName = "Hahah",
            Bio = "ahaha",
            Login = "AndrewDaw",
            Password = "0ydLucTptxT+IqsIjg1AGA==",
            Salt = "RkQW+lTSeZBypAyleNqSBg==",
            Token = "newtoken"
        };

        public static User DeletingUserModel => new()
        {
            Id = "qweqwe",
            FirstName = "Пользователь для удаления",
            LastName = "Удалённый",
            Login = "del"
        };
        
        public static User OtherUserModel => new()
        {
            Id = "sdfsdfqwertyu",
            FirstName = "Andrew",
            LastName = "Daw",
            MiddleName = "Hahah",
            Bio = "ahaha",
            Login = "AndrewDaw",
            Password = "0ydLucTptxT+IqsIjg1AGA==",
            Salt = "RkQW+lTSeZBypAyleNqSBg==",
            Token = "newtoken"
        };

        public static NewUserDto NewUserDto => new()
        {
            FirstName = "Андрей",
            LastName = "Давыдов",
            MiddleName = "Валерьевич",
            Bio = "Просто красавчик",
            Login = "AndrewDavDav",
            Password = "ahah_12_sasas"
        };
    }
}