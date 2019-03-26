using ConwaysGameOfLife;

namespace ConwaysGameOfLife
{
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