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
        [InlineData("- + 0 4 6", "0 4 + 6 -")]
        public void Prefix_ConvertsToPostfixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<PrefixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToPostfix(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("3 4 +", "3 4 +")]
        public void Postfix_ConvertsToPostfixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<PostfixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToPostfix(input);

            Assert.Equal(expected, result);
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
        [InlineData("- + 5 2 7", "- + 5 2 7")]
        public void Prefix_ConvertsToPrefixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<PrefixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToPrefix(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("5 2 + 7 -", "- + 5 2 7")]
        public void Postfix_ConvertsToPrefixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<PostfixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToPrefix(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("83 * 55 + 4 / 65", "+ * 83 55 / 4 65")]
        public void Infix_ConvertsToPrefixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<InfixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToPrefix(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("- + 5 2 7", "5 + 2 - 7")]
        public void Prefix_ConvertsToInfixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<PrefixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToInfix(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("5 2 + 7 -", "5 + 2 - 7")]
        public void Postfix_ConvertsToInfixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<PostfixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToInfix(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("83 * 55 + 4 / 65", "83 * 55 + 4 / 65")]
        public void Infix_ConvertsToInfixCorrectly(string input, string expected)
        {
            var parser = _fixture.Create<InfixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToInfix(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1 * ( 2 + 3 )", "1 2 3 + *")]
        [InlineData("( 1 + 4 ) * 2 + 3", "1 4 + 2 * 3 +")]
        [InlineData("( 8 * ( 4 - 2 ) + 2 ) * ( 2 + 3 )", "8 4 2 - * 2 + 2 3 + *")]
        public void Infix_ConvertsWithParenth(string input, string expected)
        {
            var parser = _fixture.Create<InfixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToPostfix(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1 2 3 + *", "1 * ( 2 + 3 )")]
        [InlineData("8 4 + 2 - 2 3 + *", "( 8 + 4 - 2 ) * ( 2 + 3 )")]
        [InlineData("8 4 2 - * 2 + 2 3 + *", "( 8 * ( 4 - 2 ) + 2 ) * ( 2 + 3 )")]
        public void Postfix_ConvertsWithParenth(string input, string expected)
        {
            var parser = _fixture.Create<PostfixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToInfix(input);

            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("* 1 + 2 3", "1 * ( 2 + 3 )")]
        [InlineData("* 1 + 2 ^ 3 2", "1 * ( 2 + 3 ^ 2 )")]
        public void Prefix_ConvertsWithParenth(string input, string expected)
        {
            var parser = _fixture.Create<PrefixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToInfix(input);

            Assert.Equal(expected, result);
        }
    }
}
