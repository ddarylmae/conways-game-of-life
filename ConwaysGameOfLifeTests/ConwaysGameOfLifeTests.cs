using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class ConwaysGameOfLifeTests
    {
        private Mock<IOutputWriter> _mockWriter;

        public ConwaysGameOfLifeTests()
        {
            _mockWriter = new Mock<IOutputWriter>();
        }

        [Fact]
        public void ShouldInitialiseGameOfLifeWith3X3WorldNoInitialState()
        {
            var gameOfLife = new GameOfLife();

            var inputState = "   \n   \n   ";
            var expectedState = "   \n   \n   ";

            var newState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, newState);
        }
    }
}