namespace ConwaysGameOfLife
{
    public class MessageHandler
    {
        private readonly IOutputWriter _outputWriter;

        public MessageHandler(IOutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }
        
        public void DisplayGameGuide()
        {
            _outputWriter.Write("Press return to see next state...");
        }

        public void DisplayFormattedGrid(string formattedGrid)
        {
            _outputWriter.WriteAtTop(formattedGrid);
        }
    }
}