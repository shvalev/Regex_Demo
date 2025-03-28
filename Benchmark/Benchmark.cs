using BenchmarkDotNet.Attributes;
using ReDoS;

public partial class Benchmark
{
    public static readonly string ReDosInput = "xxxxxx";
    public static readonly string ValidInput = "xxxxxxy";

    [Benchmark] public bool Default_Success() => RegexPatterns.Default.IsMatch(ValidInput);
    [Benchmark] public bool Default_ReDoS() => RegexPatterns.Default.IsMatch(ReDosInput);
    [Benchmark] public bool CompiledDefault_Success() => RegexPatterns.CompiledDefault.IsMatch(ValidInput);
    [Benchmark] public bool CompiledDefault_ReDoS() => RegexPatterns.CompiledDefault.IsMatch(ReDosInput);

    [Benchmark] public bool NonBacktracking_Success() => RegexPatterns.NonBacktracking.IsMatch(ValidInput);
    [Benchmark] public bool NonBacktracking_ReDoS() => RegexPatterns.NonBacktracking.IsMatch(ReDosInput);
    [Benchmark] public bool CompiledNonBacktracking_Success() => RegexPatterns.CompiledNonBacktracking.IsMatch(ValidInput);
    [Benchmark] public bool CompiledNonBacktracking_ReDoS() => RegexPatterns.CompiledNonBacktracking.IsMatch(ReDosInput);

    [Benchmark] public bool RightToLeft_Success() => RegexPatterns.RightToLeft.IsMatch(ValidInput);
    [Benchmark] public bool RightToLeft_ReDoS() => RegexPatterns.RightToLeft.IsMatch(ReDosInput);
    [Benchmark] public bool CompiledRightToLeft_Success() => RegexPatterns.CompiledRightToLeft.IsMatch(ValidInput);
    [Benchmark] public bool CompiledRightToLeft_ReDoS() => RegexPatterns.CompiledRightToLeft.IsMatch(ReDosInput);

    [Benchmark] public bool ECMAScript_Success() => RegexPatterns.ECMAScript.IsMatch(ValidInput);
    [Benchmark] public bool ECMAScript_ReDoS() => RegexPatterns.ECMAScript.IsMatch(ReDosInput);
    [Benchmark] public bool CompiledECMAScript_Success() => RegexPatterns.CompiledECMAScript.IsMatch(ValidInput);
    [Benchmark] public bool CompiledECMAScript_ReDoS() => RegexPatterns.CompiledECMAScript.IsMatch(ReDosInput);
    
    [Benchmark] public bool Re2_Default_Success() => Re2Patterns.IsMatch_Default(ValidInput);
    [Benchmark] public bool Re2_Default_ReDoS() => Re2Patterns.IsMatch_Default(ReDosInput);

    [Benchmark] public bool Pcre_Default_Success() => PcrePatterns.Default.IsMatch(ValidInput);
    [Benchmark] public bool Pcre_Default_ReDoS() => PcrePatterns.Default.IsMatch(ReDosInput);
    [Benchmark] public bool Pcre_Default_Success_Compilled() => PcrePatterns.DefaultCompilled.IsMatch(ValidInput);
    [Benchmark] public bool Pcre_Default_ReDoS_Compilled() => PcrePatterns.DefaultCompilled.IsMatch(ReDosInput);
}
