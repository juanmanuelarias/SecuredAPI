using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Models
{
    public static class EncodingHelper
    {
        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes)
                            .TrimEnd('=')
                            .Replace('+', '-')
                            .Replace('/', '_');
        }

        public static string ToBase64String(this string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input))
                            .TrimEnd('=')
                            .Replace('+', '-')
                            .Replace('/', '_');
        }

        public static string FromBase64String(this string input)
        {
            byte[] data = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(data);
        }

        public static byte[] ToByteArray(this string input)
        {
            input = input.Replace('-', '+').Replace('_', '/');

            int pad = 4 - (input.Length % 4);
            pad = pad > 2 ? 0 : pad;

            input = input.PadRight(input.Length + pad, '=');

            return Convert.FromBase64String(input);
        }
    }
}