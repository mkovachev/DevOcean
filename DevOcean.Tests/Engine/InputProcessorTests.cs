using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure.Interfaces;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace DevOcean.Tests.Engine
{
    public class InputProcessorTests
    {
        private readonly IInputProcessor sut;
        private readonly IWriter writer = Substitute.For<IWriter>();
        private readonly IReader reader = Substitute.For<IReader>();

        public InputProcessorTests()
        {
            this.sut = new InputProcessor(reader, writer);
        }

        [Theory]
        [InlineData("input")]
        public void ReadInput_Should_Return_List_OfType_Strings(string input)
        {
            // Arange
            this.reader.ReadLine().ToLower().Trim().Returns(input);

            // Act
            var result = this.sut.ReadInput();

            // Assert
            Assert.IsType<List<string>>(result);
        }

        [Theory]
        [InlineData("input")]
        public void ReadInput_Should_Return_List_With_Four_Elements(string input)
        {
            // Arange
            this.reader.ReadLine().ToLower().Trim().Returns(input);

            // Act
            var result = this.sut.ReadInput();

            // Assert
            Assert.True(result.Count == 4);
        }
    }
}
