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
        public void ShouldReturnNewStateWithNoLiveCellWhenCurrentStateHasNoLiveCell()
        {
            var gameOfLife = new GameOfLife();

            var inputState = "3,3\n" + 
                             "---\n---\n---";
            var expectedState = "---\n---\n---";

            var newState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, newState);
        }
        
        [Fact]
        public void ShouldReturnNewStateWithNoLiveCellWhenCurrentStateHasNoLiveCellAndNoLiveNeighbours()
        {
            var gameOfLife = new GameOfLife();

            var inputState = "3,3\n" + 
                             "---\n-#-\n---";
            var expectedState = "---\n---\n---";

            var returnedState = gameOfLife.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
    }
}