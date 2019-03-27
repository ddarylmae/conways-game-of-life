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
        public void ShouldReturnDeadStateWhenCellIsDead()
        {
            var gameOfLife = new GameOfLife();
            
            var inputState = "3,3\n" + 
                             "   \n" +
                             "   \n" +
                             "   ";
            var expectedState = " ";

            var newState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, newState);
        }
        
        [Fact]
        public void ShouldReturnDeadStateWhenCellIsLiveAndNoLiveNeighbour()
        {
            var gameOfLife = new GameOfLife();

            var inputState = "3,3\n" + 
                             "   \n" +
                             " # \n" +
                             "   ";
            var expectedState = " ";

            var returnedState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnDeadStateWhenCellIsLiveAndHasOneLiveNeighbour()
        {
            var gameOfLife = new GameOfLife();

            var inputState = "3,3\n" + 
                             "#  \n" +
                             " # \n" +
                             "   ";
            var expectedState = " ";

            var returnedState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
    }
}