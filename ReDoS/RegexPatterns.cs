using System.Text.RegularExpressions;

namespace ReDoS
{
    public partial class RegexPatterns
    {
        public static readonly Regex Default = new Regex(Patterns.Pattern, RegexOptions.None);
        public static readonly Regex NonBacktracking = new Regex(Patterns.Pattern, RegexOptions.NonBacktracking);
        public static readonly Regex RightToLeft = new Regex(Patterns.Pattern, RegexOptions.RightToLeft);
        public static readonly Regex ECMAScript = new Regex(Patterns.Pattern, RegexOptions.ECMAScript);
        public static readonly Regex Compiled = new Regex(Patterns.Pattern, RegexOptions.Compiled);
        public static readonly Regex CompiledDefault = CompiledDefaultMethod();
        public static readonly Regex CompiledNonBacktracking = CompiledNonBacktrackingMethod();
        public static readonly Regex CompiledRightToLeft = CompiledRightToLeftMethod();
        public static readonly Regex CompiledECMAScript = CompiledECMAScriptMethod();

        [GeneratedRegex(Patterns.Pattern)]
        private static partial Regex CompiledDefaultMethod();

        [GeneratedRegex(Patterns.Pattern, RegexOptions.RightToLeft)]
        private static partial Regex CompiledRightToLeftMethod();

        [GeneratedRegex(Patterns.Pattern, RegexOptions.NonBacktracking)]
        private static partial Regex CompiledNonBacktrackingMethod();

        [GeneratedRegex(Patterns.Pattern, RegexOptions.ECMAScript)]
        private static partial Regex CompiledECMAScriptMethod();
    }
}
