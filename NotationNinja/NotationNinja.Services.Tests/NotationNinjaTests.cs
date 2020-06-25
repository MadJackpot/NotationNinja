using AutoFixture;
using NotationNinja.Services.NotationParsers;
using System;
using Xunit;

namespace NotationNinja.Services.Tests
{
    public class NotationNinjaTests
    {
        private readonly Fixture _fixture;

        public NotationNinjaTests()
        {
            _fixture = new Fixture();
        }

        [Theory]
        [InlineData("7 + 1 / 2", "7 1 2 / +")]
        [InlineData("91 - 42 * 6 + 1", "91 42 6 * - 1 +")]
        [InlineData("3 + 4", "3 4 +")]
        public void Infix_ConvertsToPostfixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<InfixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToPostfix(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("- + 0 4 6", "0 4 + 6 -")]
        public void Prefix_ConvertsToPostfixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<PrefixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToPostfix(input);

            Assert.Equal(expected, result);
        }
    }
}
