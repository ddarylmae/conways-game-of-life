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
        public void ShouldReturnDeadStateWhenDeadCellHasNoLiveNeighbour()
        {
            var gameOfLife = new GameOfLife();
            
            var inputState = "   \n" +
                             "   \n" +
                             "   ";
            var expectedState = " ";

            var newState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, newState);
        }
        
        [Fact]
        public void ShouldReturnDeadStateWhenLiveCellHasNoLiveNeighbour()
        {
            var gameOfLife = new GameOfLife();

            var inputState = "   \n" +
                             " # \n" +
                             "   ";
            var expectedState = " ";

            var returnedState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnDeadStateWhenDeadCellHasOneLiveNeighbour()
        {
            var gameOfLife = new GameOfLife();

            var inputState = "#  \n" +
                             " # \n" +
                             "   ";
            var expectedState = " ";

            var returnedState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnLiveStateWhenLiveCellHasTwoLiveNeighbours()
        {
            var gameOfLife = new GameOfLife();

            var inputState = "#  \n" +
                             " ##\n" +
                             "   ";
            var expectedState = "#";

            var returnedState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
    }
}