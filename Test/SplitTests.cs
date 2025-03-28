using FluentAssertions;
using System.Text.RegularExpressions;

namespace Test
{
    public partial class SplitTests
    {
        /*
         * возможные символы разделители ';' '|' или пробел
         */
        [GeneratedRegex(@"([;|]|\s)", RegexOptions.IgnoreCase | RegexOptions.NonBacktracking)]
        private static partial Regex DelimeterPattern();

        public static TheoryData<string, string, string, string> TestData =>
            new()
            {
                {"Иванов;Иван;Иванович", "Иванов", "Иван", "Иванович"},
                {"Петров|Петр|Петрович", "Петров", "Петр", "Петрович"},
                {"Васильев Василий Васильевич", "Васильев", "Василий", "Васильевич"}
            };

        [Theory]
        [MemberData(nameof(TestData))]
        public void SplitPattern_ShouldBe_Splitted(string data, string exected1, string exected2, string exected3)
        {
            // Arrange
            // Act
            var result = DelimeterPattern().Split(data);

            // Assert
            result.Should().HaveCount(5);

            // Иванов
            result[0].Should().Be(exected1);

            // ; - разделитель
            DelimeterPattern().IsMatch(result[1]).Should().BeTrue();

            // Иван
            result[2].Should().Be(exected2);

            // ; - разделитель
            DelimeterPattern().IsMatch(result[3]).Should().BeTrue();

            // Иванович
            result[4].Should().Be(exected3);
            DelimeterPattern().IsMatch(result[4]).Should().BeFalse();
        }

        /*
         * Символы для значений (не разделители)
         */
        [GeneratedRegex(@"([а-я]+)", RegexOptions.IgnoreCase | RegexOptions.NonBacktracking)]
        private static partial Regex WordPattern();

        [Theory]
        [MemberData(nameof(TestData))]
        public void WordPattern_ShouldBe_Splitted(string data, string exected1, string exected2, string exected3)
        {
            // Arrange
            // Act
            var result = WordPattern().Split(data);

            // Assert
            result.Should().HaveCount(7);
            
            result[0].Should().Be(string.Empty);

            // Иванов
            result[1].Should().Be(exected1);

            // ;
            WordPattern().IsMatch(result[2]).Should().BeFalse();

            // Иван
            result[3].Should().Be(exected2);

            // ;
            WordPattern().IsMatch(result[4]).Should().BeFalse();

            // Иванович
            result[5].Should().Be(exected3);

            result[6].Should().Be(string.Empty);
        }

        /*
         * Метод Split всегда возвражает объекты до и после совпадения, в т.ч. пустые строки
         */

        [Theory]
        [MemberData(nameof(TestData))]
        public void WordPattern_ShouldBe_Matched(string data, string exected1, string exected2, string exected3)
        {
            // Arrange
            // Act
            var result = WordPattern().Matches(data);

            // Assert
            result.Should().HaveCount(3);
            result[0].Value.Should().Be(exected1);
            result[1].Value.Should().Be(exected2);
            result[2].Value.Should().Be(exected3);
        }
    }
}
