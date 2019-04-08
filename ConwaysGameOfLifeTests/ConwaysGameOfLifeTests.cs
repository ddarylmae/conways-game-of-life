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
        public void ShouldDisplayInitialWorldStateAndGameGuideMessageOnGameStart()
        {
            var fileContent   =  "3,3\n" +
                                 "...\n" +
                                 "...\n" +
                                 "...\n";
            var expectedOutput = "   \n" +
                                 "   \n" +
                                 "   \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);
            
            InitializeNewGame();
            
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedOutput));
            _mockOutputWriter.Verify(writer => writer.Write("Press return to see next state..."));
        }
        
        [Fact]
        public void ShouldDisplayEmptyWorldWhenNoLiveCell()
        {
            var fileContent =   "3,3\n" +
                                "...\n" +
                                "...\n" +
                                "...\n";
            var initialState =  "   \n" +
                                "   \n" +
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
        public void ShouldBecomeDeadCellWhenLiveCellHasNoLiveNeighbors()
        {
            var fileContent =   "3,3\n" +
                                "...\n" +
                                ".#.\n" +
                                "...\n";
            var initialState =  "   \n" +
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
        public void ShouldBecomeDeadCellWhenLiveCellHasOneLiveNeighbor()
        {
            var fileContent =  "3,3\n" +
                                ".#.\n" +
                                ".#.\n" +
                                "...\n";
            var initialState =  " # \n" +
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
        public void ShouldStayLiveWhenLiveCellHasTwoLiveNeighbors()
        {
            var fileContent = "5,5\n" +
                             ".....\n" +
                             ".#...\n" +
                             "..#..\n" +
                             "...#.\n" + 
                             ".....\n";
            var initialState =  "     \n" +
                                " #   \n" +
                                "  #  \n" +
                                "   # \n" + 
                                "     \n";
            var expectedState = "     \n" +
                                "     \n" +
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
        public void ShouldStayLiveWhenLiveCellHasThreeLiveNeighbors()
        {
            var fileContent = "5,5\n" +
                              ".....\n" +
                              ".#.#.\n" +
                              "..#..\n" +
                              "...#.\n" + 
                              ".....\n";
            var initialState =  "     \n" +
                                " # # \n" +
                                "  #  \n" +
                                "   # \n" + 
                                "     \n";
            var expectedState = "     \n" +
                                "  #  \n" +
                                "  ## \n" +
                                "     \n" + 
                                "     \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);

            InitializeNewGame();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedState));
        }
        
        [Fact]
        public void ShouldBecomeLiveCellWhenDeadCellHasThreeLiveNeighbors()
        {
            var fileContent =   "5,5\n" +
                                ".....\n" +
                                ".#.#.\n" +
                                "..##.\n" +
                                ".....\n" + 
                                ".....\n";
            var initialState =  "     \n" +
                                " # # \n" +
                                "  ## \n" +
                                "     \n" + 
                                "     \n";
            var expectedState = "     \n" +
                                "   # \n" +
                                "  ## \n" +
                                "     \n" + 
                                "     \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);

            InitializeNewGame();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(expectedState));
        }
        
        [Fact]
        public void ShouldDisplayNextStateBasedOnPreviousState()
        {
            var fileContent =  "8,6\n" +
                               "......\n" +
                               "......\n" +
                               "...#..\n" +
                               "..#...\n" +
                               "..##..\n" +
                               "...#..\n" +
                               "......\n" + 
                               "......\n";
            var initialState = "      \n" +
                               "      \n" +
                               "   #  \n" +
                               "  #   \n" +
                               "  ##  \n" +
                               "   #  \n" +
                               "      \n" + 
                               "      \n";
            var stateAfterFirstStep =   "      \n" +
                                        "      \n" +
                                        "      \n" +
                                        "  #   \n" +
                                        "  ##  \n" +
                                        "  ##  \n" +
                                        "      \n" + 
                                        "      \n";
            var stateAfterSecondStep =  "      \n" +
                                        "      \n" +
                                        "      \n" +
                                        "  ##  \n" +
                                        " #    \n" +
                                        "  ##  \n" +
                                        "      \n" + 
                                        "      \n";
            
            _mockInputReader.Setup(reader => reader.GetStringContent()).Returns(fileContent);

            InitializeNewGame();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(initialState));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(stateAfterFirstStep));
            
            Game.Step();
            _mockOutputWriter.Verify(writer => writer.WriteAtTop(stateAfterSecondStep));
        }
    }
}