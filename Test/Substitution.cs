using FluentAssertions;
using System.Text.RegularExpressions;

namespace Test
{
    public partial class Substitution
    {
        [GeneratedRegex(@"[\D]+", RegexOptions.IgnoreCase | RegexOptions.NonBacktracking)]
        private static partial Regex SubstitutePhonePattern();

        [Theory]
        [InlineData("+7(999)959-3233", "79999593233")]
        [InlineData("+7 999 959 32  33", "79999593233")]
        [InlineData("+7 (999) 959-32-33", "79999593233")]
        [InlineData("+7-999-959-32-33", "79999593233")]
        [InlineData("7[999]959-32-33", "79999593233")]
        public void SubstitutePhonePattern_ShouldNormalizePhoneData(string data, string exected)
        {
            // Arrange
            const string target = "";
            // Act
            var result = SubstitutePhonePattern().Replace(data, target);

            // Assert
            result.Should().Be(exected);
        }

    }
}
