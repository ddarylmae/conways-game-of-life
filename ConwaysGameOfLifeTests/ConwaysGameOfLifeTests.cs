using System.Threading;
using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class ConwaysGameOfLifeTests
    {
        private GameOfLife Game { get; }
        private readonly Mock<IOutputWriter> _mockOutputWriter;
        private readonly Mock<IInputReader> _mockInputReader;

        public ConwaysGameOfLifeTests()
        {
            _mockOutputWriter = new Mock<IOutputWriter>();
            _mockInputReader = new Mock<IInputReader>();
            Game = new GameOfLife(_mockOutputWriter.Object, _mockInputReader.Object);
        }

        [Fact]
        public void ShouldDisplayInitialWorldStateWhenGameHasNotStarted()
        {
            var fileContent = "3,3\n" +
                              "...\n" +
                              "...\n" +
                              "...\n";
            var expectedOutput = "   \n" +
                                 "   \n" +
                                 "   \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);
            
            Game.Step();
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedOutput));
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

            Game.Step();
            Game.Step();
            Game.Step();
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.Step();
            Game.Step();
            
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
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(initialState);

            Game.Step();
            Game.Step();
            
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.Step();
            _mockOutputWriter.Verify(writer => writer.Write(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.Step();
            _mockOutputWriter.Verify(writer => writer.Write(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.Step();
            _mockOutputWriter.Verify(writer => writer.Write(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
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

            Game.Step();
            _mockOutputWriter.Verify(writer => writer.Write(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.Write(expectedState));
        }
    }
}