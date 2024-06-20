using System;
using System.Text;

namespace bengogogadget.core.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64String(this string value)
        {
            var inputBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(inputBytes);
        }

        public static string FromBase64String(this string value)
        {
            var base64EncodedBytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
