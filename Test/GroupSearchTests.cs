using FluentAssertions;
using System.Text.RegularExpressions;

namespace Test
{
    public partial class GroupSearchTests
    {
        /*
         * инн:(\s?) - после инн: может быть 0-1 пробел
         * (?<inn>[0-9]{10}|[0-9]{12}) - значение ИНН может быть 10 или 12 чисел
         * ([\D]+|\s+|$) - после значения ИНН должено быть не число(один и более) или пробел(ы) или конец строки
         */
        [GeneratedRegex(@"инн:(\s?)(?<inn>[0-9]{10}|[0-9]{12})([\D]+|\s+|$)", RegexOptions.IgnoreCase | RegexOptions.NonBacktracking)]
        private static partial Regex InnPattern();

        [Theory]
        [InlineData("инн: 1234567890 test", "1234567890", true)]
        [InlineData("инн: 123456789012", "123456789012", true)]
        [InlineData("инн:1234567890", "1234567890", true)]
        [InlineData("ИНН:123456789012", "123456789012", true)]
        [InlineData("Иванов Иван ИНН:1234567890 г.Пермь", "1234567890", true)]
        [InlineData("ИвановИванИНН:1234567890г.Пермь", "1234567890", true)]
        [InlineData("Иванов;Иван;ИНН:1234567890;г.Пермь;", "1234567890", true)]
        [InlineData("инн: 12345678901", "", false)]
        [InlineData("инн: 1234567890123", "", false)]
        [InlineData("и нн: 123456789012", "", false)]
        [InlineData("1234567890 инн", "", false)]
        public void InnPattern_ShouldBe_ExpectedNamedGroup(string data, string exected, bool exists)
        {
            // Arrange
            /*
             * Требуется из строки извлеч значение ИНН
             * у Физ. лиц инн 12 чисел у юр. лиц 10 чисел
             * перед значением должно быть слово "инн:" возможно, раделенное пробелом
             */
            const string groupKey = "inn";
            // Act
            var result = InnPattern().Match(data);

            // Assert
            result.Groups.Keys.Contains(groupKey).Should().Be(exists);
            if (exists)
            {
                var value = result.Groups[groupKey];
                value.Value.Should().Be(exected);
            }
        }

        /*
         * ^[^()]* - в начале строки 0 и более символов которые не являются '(' или ')'
         * (?'Open'[(]) - именованная группа для поиска символа '('
         * (((?'Open'\()[^()]*)+ - одно или несколько вхождений в смволы: '(' за которой идет несколько символов не являющимися скобками
         * ((?'Close-Open'\))[^()]*)+)* - Сопоставление с ')', назначение подстроки между группой Open 
         *                                и текущей группой группе Close и удаление определения группы Open
         */
        [GeneratedRegex(@"^[^()]*(((?'Open'\()[^()]*)+((?'Close-Open'\))[^()]*)+)*")]
        private static partial Regex BalancedGroupPattern();

        [Fact]
        public void BalancedGroupPattern_ShouldReturn_expectedValue()
        {
            // Arrange
            var data = "(Root(Node1(Node2))(Node3))";

            // Act
            var matches = BalancedGroupPattern().Match(data);
            var closeGroup = matches.Groups["Close"];

            // Assert
            closeGroup.Captures.Should().HaveCount(4);

            var captures = closeGroup.Captures.Select(x => x.Value).OrderBy(x => x).ToArray();
            captures.Should().BeEquivalentTo(new[]
            {
                "Node1(Node2)",
                "Node2",
                "Node3",
                "Root(Node1(Node2))(Node3)"
            });
        }
    }
}
