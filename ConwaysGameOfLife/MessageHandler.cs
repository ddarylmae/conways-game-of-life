namespace ConwaysGameOfLife
{
    public class MessageHandler
    {
        private IOutputWriter OutputWriter;

        public MessageHandler(IOutputWriter outputWriter)
        {
            OutputWriter = outputWriter;
        }
        
        public void DisplayGameGuide()
        {
            OutputWriter.Write("Press return to see next state...");
        }

        public void DisplayFormattedGrid(string formattedGrid)
        {
            OutputWriter.WriteAtTop(formattedGrid);
        }
    }
}