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
            Token = "newtoken",
            Email = "a@a.a",
            IsEmailConfirmed = true
        };
        
        public static User UserModelWithNoConfirm => new()
        {
            Id = "qwertyu1",
            FirstName = "Andrewa",
            LastName = "Dawa",
            MiddleName = "Hahah",
            Bio = "ahaha",
            Login = "AndrewDawa",
            Password = "0ydLucTptxT+IqsIjg1AGA==",
            Salt = "RkQW+lTSeZBypAyleNqSBg==",
            Token = "newtoken1",
            Email = "aa@a.a",
            IsEmailConfirmed = false
        };

        public static User DeletingUserModel => new()
        {
            Id = "qweqwe",
            FirstName = "Пользователь для удаления",
            LastName = "Удалённый",
            Login = "del",
            Email = "a@a.a",
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
            Email = "a@a.a",
            Token = "newtoken"
        };

        public static NewUserDto NewUserDto => new()
        {
            FirstName = "Андрей",
            LastName = "Давыдов",
            MiddleName = "Валерьевич",
            Bio = "Просто красавчик",
            Login = "AndrewDavDav",
            Email = "a@a.a",
            Password = "ahah_12_sasas",
            ConfirmPassword = "ahah_12_sasas"
        };
    }
}