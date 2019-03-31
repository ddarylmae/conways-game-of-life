using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class ConwaysGameOfLifeTests
    {
        private GameOfLife Game { get; set; }
        private readonly Mock<IOutputWriter> _mockOutputWriter;
        private readonly Mock<IInputReader> _mockInputProcessor;

        public ConwaysGameOfLifeTests()
        {
            _mockOutputWriter = new Mock<IOutputWriter>();
            _mockInputProcessor = new Mock<IInputReader>();
            Game = new GameOfLife(_mockOutputWriter.Object, _mockInputProcessor.Object);
        }

        [Fact]
        public void ShouldReturnEmptyWorldWhenNoLiveCell()
        {
            var initialState = "3,3\n" +
                             "...\n" +
                             "...\n" +
                             "...";
            var expectedState = "   \n" +
                                "   \n" +
                                "   \n";

            _mockInputProcessor.Setup(reader => reader.GetStringContent()).Returns(initialState);

            Game.Start();
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
        }
        
        [Fact]
        public void ShouldReturnEmptyWorldWhenOneLiveCellPresent()
        {
            var initialState = "3,3\n" +
                             "...\n" +
                             ".#.\n" +
                             "...";
            var expectedState = "   \n" +
                                "   \n" +
                                "   \n";
            
            _mockInputProcessor.Setup(reader => reader.GetStringContent()).Returns(initialState);

            Game.Start();
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
        }
        
        [Fact]
        public void ShouldReturnEmptyWorldWhenTwoLiveCellsPresent()
        {
            var initialState = "3,3\n" +
                             ".#.\n" +
                             ".#.\n" +
                             "...";
            var expectedState = "   \n" +
                                "   \n" +
                                "   \n";
            
            _mockInputProcessor.Setup(reader => reader.GetStringContent()).Returns(initialState);

            Game.Start();
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
        }
        
        [Fact]
        public void ShouldReturnNewStateWhenThreeLiveCellsPresent()
        {
            var initialState = "5,5\n" +
                             ".....\n" +
                             ".#...\n" +
                             "..##.\n" +
                             ".....\n" + 
                             ".....\n";
            var expectedState = "     \n" +
                                "  #  \n" +
                                "  #  \n" +
                                "     \n" + 
                                "     \n";
            
            _mockInputProcessor.Setup(reader => reader.GetStringContent()).Returns(initialState);

            Game.Start();
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
        }
        
        [Fact]
        public void ShouldReturnNewStateWhen3X3WorldThreeLiveCellsPresent()
        {
            var initialState = "3,3\n" +
                             "#..\n" +
                             ".##\n" +
                             "...";
            var expectedState = "###\n" +
                                "###\n" +
                                "###\n";
            
            _mockInputProcessor.Setup(reader => reader.GetStringContent()).Returns(initialState);

            Game.Start();
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
        }
        
        [Fact]
        public void ShouldReturnNewStateWhenFourLiveCellsPresent()
        {
            var initialState = "5,5\n" +
                             ".....\n" +
                             ".#...\n" +
                             ".###.\n" +
                             ".....\n" + 
                             ".....\n";
            var expectedState = "     \n" +
                                " #   \n" +
                                " ##  \n" +
                                "  #  \n" + 
                                "     \n";
            
            _mockInputProcessor.Setup(reader => reader.GetStringContent()).Returns(initialState);

            Game.Start();
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
        }
    }
}