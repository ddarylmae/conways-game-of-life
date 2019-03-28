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
        public void ShouldReturnEmptyWorldWhenNoLiveCell()
        {   
            var inputState = "3,3\n" +
                             "...\n" +
                             "...\n" +
                             "...";
            var expectedState = "   \n" +
                                "   \n" +
                                "   ";

            var newState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, newState);
        }
        
        [Fact]
        public void ShouldReturnEmptyWorldWhenOneLiveCellPresent()
        {
            var inputState = "3,3\n" +
                             "...\n" +
                             ".#.\n" +
                             "...";
            var expectedState = "   \n" +
                                "   \n" +
                                "   ";

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnEmptyWorldWhenTwoLiveCellsPresent()
        {
            var inputState = "3,3\n" +
                             ".#.\n" +
                             ".#.\n" +
                             "...";
            var expectedState = "   \n" +
                                "   \n" +
                                "   ";

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnNewStateWhenThreeLiveCellsPresent()
        {
            var inputState = "3,3\n" +
                             "#  \n" +
                             " ##\n" +
                             "   ";
            var expectedState = "   \n" +
                                " # \n" +
                                "   ";

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
//        [Fact]
//        public void ShouldReturnNewStateWhenFourLiveCellsPresent()
//        {
//            var inputState = "#  \n" +
//                             "###\n" +
//                             "   ";
//            var expectedState = "#  \n" +
//                                "## \n" +
//                                "# #";
//
//            var returnedState = Game.GetNewState(inputState);
//            
//            Assert.Equal(expectedState, returnedState);
//        }
//        
//        [Fact]
//        public void ShouldReturnNewStateWhenFiveLiveCellsPresent()
//        {
//            var inputState = "#  \n" +
//                             "###\n" +
//                             " # ";
//            var expectedState = CellState.Dead;
//
//            var returnedState = Game.GetNewState(inputState);
//            
//            Assert.Equal(expectedState, returnedState);
//        }
    }
}