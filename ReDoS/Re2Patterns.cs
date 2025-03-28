using Microsoft.RE2.Managed;
using Microsoft.Strings.Interop;
using System.Text.RegularExpressions;

namespace ReDoS
{
    public static class Re2Patterns
    {
        public static bool IsMatch_Default(string data) =>
            IsMatch(data, RegexOptions.None);

        private static bool IsMatch(string data, System.Text.RegularExpressions.RegexOptions options)
        {
            byte[] buffer = null;
            var sample = String8.Convert(data, ref buffer);
            return Regex2.IsMatch(sample, Patterns.Pattern, RegexOptions.IgnoreCase | options);
        }
    }
}
