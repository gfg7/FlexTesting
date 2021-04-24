using System;
using System.Security.Cryptography;
using System.Text;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Core.Contract.Helpers
{
    public static class PasswordHelper
    {
        public static HashResult GeneratePassword(string password)
        {
            var rnd = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rnd.GetBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var md = MD5.Create();
            var saltedPass = password + salt;
            var hash = Convert.ToBase64String(md.ComputeHash(Encoding.Unicode.GetBytes(saltedPass)));

            return new HashResult(hash, salt);
        }

        public static bool ComparePassword(Models.User user, string password)
        {
            var md = MD5.Create();
            var saltedPass = password + user?.Salt;
            var hash = Convert.ToBase64String(md.ComputeHash(Encoding.Unicode.GetBytes(saltedPass)));

            return hash == user?.Password;
        }
    }

    public record HashResult(string Hash, string Salt)
    { }
}