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
        [InlineData("1 + 2 / 3", "1 2 3 / +")]
        [InlineData("1 + 2 - 3", "1 2 + 3 -")]
        [InlineData("1 * 2 * 3", "1 2 * 3 *")]
        public void Test(string input, string expected)
        {
            var parser = _fixture.Create<InfixNotationParser>();

            var ninja = new NotationNinja(parser);

            var result = ninja.ToPostfix(input);

            Assert.Equal(expected, result);
        }
    }
}
