using System;

namespace FlexTesting.Core.Contract.Helpers
{
    public static class RandomHelper
    {
        private const string Symbols = "qwertyuiopasdfghjklzxcvbnm1234567890";

        public static string GenerateRandomString(int length = 10)
        {
            var random = new Random();
            var str = string.Empty;
            for (var i = 0; i < length; i++)
            {
                str += Symbols[random.Next(Symbols.Length)];
            }

            return str;
        }
    }
}