namespace ConwaysGameOfLife
{
    public class GameOfLife
    {
        private GridFormatter GridFormatter { get; }
        private IWorld World { get; set; }
        private StateGenerator StateGenerator { get; }
        private IOutputWriter OutputWriter { get; }
        
        public GameOfLife(IInputReader inputReader, IOutputWriter outputWriter)
        {   
            StateGenerator = new StateGenerator();
            var inputProcessor = new WorldBuilder(inputReader);
            GridFormatter = new GridFormatter();
            OutputWriter = outputWriter;
            
            World = inputProcessor.GetWorld();
            
            DisplayInitialGameOutput();
        }

        private void DisplayInitialGameOutput()
        {
            DisplayWorldState();
            DisplayGameGuide();
        }

        private void DisplayGameGuide()
        {
            OutputWriter.Write("Press return to see next state...");
        }

        public void Step()
        {
            World = StateGenerator.GetNextState(World);
            
            DisplayWorldState();
        }

        private void DisplayWorldState()
        {
            var formattedWorld = GridFormatter.Format(World);
            OutputWriter.WriteAtTop(formattedWorld);
        }
    }
}