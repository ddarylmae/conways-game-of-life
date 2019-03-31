using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class ConwaysGameOfLifeTests
    {
        private GameOfLife Game { get; set; }
        private readonly Mock<IOutputWriter> _mockOutputWriter;

        public ConwaysGameOfLifeTests()
        {
            _mockOutputWriter = new Mock<IOutputWriter>();
            Game = new GameOfLife(_mockOutputWriter.Object);
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

            Game.SetInitialState(inputState);
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.SetInitialState(inputState);
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.SetInitialState(inputState);
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.SetInitialState(inputState);
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.SetInitialState(inputState);
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.SetInitialState(inputState);
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
        }
    }
}