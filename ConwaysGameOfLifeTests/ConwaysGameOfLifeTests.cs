using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class ConwaysGameOfLifeTests
    {
        private GameOfLife Game { get; set; }

        public ConwaysGameOfLifeTests()
        {
            Game = new GameOfLife();
        }

        [Fact]
        public void ShouldReturnDeadStateWhenDeadCellHasNoLiveNeighbour()
        {   
            var inputState = "   \n" +
                             "   \n" +
                             "   ";
            var expectedState = CellState.Dead;

            var newState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, newState);
        }
        
        [Fact]
        public void ShouldReturnDeadStateWhenLiveCellHasNoLiveNeighbour()
        {
            var inputState = "   \n" +
                             " # \n" +
                             "   ";
            var expectedState = CellState.Dead;

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnDeadStateWhenDeadCellHasOneLiveNeighbour()
        {
            var inputState = "#  \n" +
                             " # \n" +
                             "   ";
            var expectedState = CellState.Dead;

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnLiveStateWhenLiveCellHasTwoLiveNeighbours()
        {
            var inputState = "#  \n" +
                             " ##\n" +
                             "   ";
            var expectedState = CellState.Live;

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnLiveStateWhenLiveCellHasThreeLiveNeighbours()
        {
            var inputState = "#  \n" +
                             "###\n" +
                             "   ";
            var expectedState = CellState.Live;

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnDeadStateWhenLiveCellHasFourLiveNeighbours()
        {
            var inputState = "#  \n" +
                             "###\n" +
                             " # ";
            var expectedState = CellState.Dead;

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
    }
}