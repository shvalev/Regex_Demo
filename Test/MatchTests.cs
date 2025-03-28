using FluentAssertions;
using System.Text.RegularExpressions;

namespace Test
{
    public partial class MatchTests
    {
        /*
         * !!! Внимание !!! --- НЕИСПОЛЬЗОВАТЬ В PRODUCTION-КОДЕ --- !!! Внимание !!!
         * 
         * ^[a-z0-9.]+ - в начале строки должна быть 1 и более из латинских смиволов или чисел
         * @[a-z0-9]+ - после символа '@' должна быть 1 и более латинских смиволов или чисел
         * \.[a-z]+ - после символа '.' должна быть 1 и более латинских символов 
         */
        [GeneratedRegex(@"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+", RegexOptions.IgnoreCase | RegexOptions.NonBacktracking)]
        private static partial Regex EmailPattern();

        [Theory]
        [InlineData("test@domain.net", true)]
        [InlineData("12test@domain.net", true)]
        [InlineData("12test@domain22.net", true)]
        [InlineData("12test@domain22.net11", true)]
        [InlineData("@domain.net", false)]
        [InlineData("test@ .net", false)]
        [InlineData("test@domain", false)]
        [InlineData("test@domain. net", false)]
        [InlineData("t est@domain.net", false)]
        public void EmailPattern_IsMatch_ShouldBeExpected(string data, bool exected)
        {
            // Arrange
            // Act
            var result = EmailPattern().IsMatch(data);

            // Assert
            result.Should().Be(exected);
        }
    }
}
