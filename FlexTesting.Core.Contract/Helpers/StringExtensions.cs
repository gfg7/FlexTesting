using System;
using System.Linq;
using Unidecode.NET;

namespace FlexTesting.Core.Contract.Helpers
{
    public static class StringExtensions
    {
        public static string FormatToSelector(this string str)
        {
            var translit = str.Unidecode();
            var chars = translit
                .ToLower()
                .Replace(' ', '-')
                .Where(x => x == '-' || char.IsLetter(x))
                .ToArray();
            return new string(chars).Trim('-');
        }
    }
}