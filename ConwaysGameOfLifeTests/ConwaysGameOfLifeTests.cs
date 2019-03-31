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
                                "   \n";

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
                                "   \n";

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
                                "   \n";

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnNewStateWhenThreeLiveCellsPresent()
        {
            var inputState = "5,5\n" +
                             "     \n" +
                             " #   \n" +
                             "  ## \n" +
                             "     \n" + 
                             "     \n";
            var expectedState = "     \n" +
                                "  #  \n" +
                                "  #  \n" +
                                "     \n" + 
                                "     \n";

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnNewStateWhen3X3WorldThreeLiveCellsPresent()
        {
            var inputState = "3,3\n" +
                             "#  \n" +
                             " ##\n" +
                             "   ";
            var expectedState = "###\n" +
                                "###\n" +
                                "###\n";

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
        
        [Fact]
        public void ShouldReturnNewStateWhenFourLiveCellsPresent()
        {
            var inputState = "5,5\n" +
                             "     \n" +
                             " #   \n" +
                             " ### \n" +
                             "     \n" + 
                             "     \n";
            var expectedState = "     \n" +
                                " #   \n" +
                                " ##  \n" +
                                "  #  \n" + 
                                "     \n";

            var returnedState = Game.GetNewState(inputState);
            
            Assert.Equal(expectedState, returnedState);
        }
    }
}