using PCRE;

namespace ReDoS
{
    public static class PcrePatterns
    {
        public static readonly PcreRegex Default = new PcreRegex(Patterns.Pattern, PcreOptions.IgnoreCase);
        public static readonly PcreRegex DefaultCompilled = new PcreRegex(Patterns.Pattern, PcreOptions.IgnoreCase | PcreOptions.Compiled);
    }
}
