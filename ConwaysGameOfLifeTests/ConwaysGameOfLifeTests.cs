using System.Threading;
using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class ConwaysGameOfLifeTests
    {
        private GameOfLife Game { get; set; }
        private readonly Mock<IOutputWriter> _mockOutputWriter;
        private readonly Mock<IInputReader> _mockInputReader;

        public ConwaysGameOfLifeTests()
        {
            _mockOutputWriter = new Mock<IOutputWriter>();
            _mockInputReader = new Mock<IInputReader>();
        }
        
        private void InitializeNewGame()
        {
            Game = new GameOfLife(_mockInputReader.Object, _mockOutputWriter.Object);
        }

        [Fact]
        public void ShouldDisplayInitialWorldState()
        {
            var fileContent = "3,3\n" +
                              "...\n" +
                              "...\n" +
                              "...\n";
            var expectedOutput = "   \n" +
                                 "   \n" +
                                 "   \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);
            
            InitializeNewGame();
            
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedOutput));
        }
        
        [Fact]
        public void ShouldDisplayCorrectStateAfterThreePlays()
        {
            var initialState = "8,6\n" +
                               "......\n" +
                               "......\n" +
                               "...#..\n" +
                               "..#...\n" +
                               "..##..\n" +
                               "...#..\n" +
                               "......\n" + 
                               "......\n";
            var expectedState =  "      \n" +
                                 "      \n" +
                                 "      \n" +
                                 "  ##  \n" +
                                 " #    \n" +
                                 "  ##  \n" +
                                 "      \n" + 
                                 "      \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(initialState);

            InitializeNewGame();
            Game.Step();
            Game.Step();
            
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedState));
        }
        
        [Fact]
        public void ShouldReturnEmptyWorldWhenNoLiveCell()
        {
            var fileContent = "3,3\n" +
                              "...\n" +
                              "...\n" +
                              "...";
            var expectedState = "   \n" +
                                "   \n" +
                                "   \n";

            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);

            InitializeNewGame();
            Game.Step();
            
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedState));
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
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(initialState);

            InitializeNewGame();
            
            Game.Step();
            
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedState));
        }
        
        [Fact]
        public void ShouldReturnEmptyWorldWhenTwoLiveCellsPresent()
        {
            var fileContent = "3,3\n" +
                               ".#.\n" +
                               ".#.\n" +
                               "...\n";
            var initialState = " # \n" +
                               " # \n" +
                               "   \n";
            var expectedState = "   \n" +
                                "   \n" +
                                "   \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);

            InitializeNewGame();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedState));
        }
        
        [Fact]
        public void ShouldReturnNewStateWhenThreeLiveCellsPresent()
        {
            var fileContent = "5,5\n" +
                             ".....\n" +
                             ".#...\n" +
                             "..##.\n" +
                             ".....\n" + 
                             ".....\n";
            var initialState =  "     \n" +
                                " #   \n" +
                                "  ## \n" +
                                "     \n" + 
                                "     \n";
            var expectedState = "     \n" +
                                "  #  \n" +
                                "  #  \n" +
                                "     \n" + 
                                "     \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);

            InitializeNewGame();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedState));
        }
        
        [Fact]
        public void ShouldReturnNewStateWhen3X3WorldThreeLiveCellsPresent()
        {
            var fileContent = "3,3\n" +
                             "#..\n" +
                             ".##\n" +
                             "...\n";
            var initialState =  "#  \n" +
                                " ##\n" +
                                "   \n";
            var expectedState = "###\n" +
                                "###\n" +
                                "###\n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);

            InitializeNewGame();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedState));
        }
        
        [Fact]
        public void ShouldReturnNewStateWhenFourLiveCellsPresent()
        {
            var fileContent = "5,5\n" +
                             ".....\n" +
                             ".#...\n" +
                             ".###.\n" +
                             ".....\n" + 
                             ".....\n";
            var initialState =  "     \n" +
                                " #   \n" +
                                " ### \n" +
                                "     \n" + 
                                "     \n";
            var expectedState = "     \n" +
                                " #   \n" +
                                " ##  \n" +
                                "  #  \n" + 
                                "     \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);

            InitializeNewGame();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedState));
        }
    }
}