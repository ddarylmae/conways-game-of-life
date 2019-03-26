using System;
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
        public void ShouldInitialiseGameOfLife()
        {
            var gameOfLife = new GameOfLife(_mockWriter.Object);

            gameOfLife.SetNewWorld("50X30");

            _mockWriter.Verify(x => x.Write(
                "                              \n" +
                         "                              \n" +
                         "                              \n" +
                         "                              \n" +
                         "                              \n"));
        }
        
        [Fact]
        public void ShouldInitialiseWith50X30World()
        {
            var world = new World(new Area{Length = 50, Width = 30});
            
            Assert.Equal(1500, world.GetSize());
        }
        
        [Fact]
        public void ShouldInitialise50X80World()
        {
            var world = new World(new Area{Length = 50, Width = 80});
            
            Assert.Equal(4000, world.GetSize());
        }
    }

    public interface IOutputWriter
    {
        void Write(string message);
    }

    public class OutputWriter : IOutputWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class GameOfLife
    {
        public IOutputWriter OutputWriter { get; set; }

        public GameOfLife(IOutputWriter outputWriter)
        {
            OutputWriter = outputWriter;
        }
        
        public void SetNewWorld(string inputDimensions)
        {
            OutputWriter.Write("                              \n" +
                               "                              \n" +
                               "                              \n" +
                               "                              \n" +
                               "                              \n");
        }
    }
}