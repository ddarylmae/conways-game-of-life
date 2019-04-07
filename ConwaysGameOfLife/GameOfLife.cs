using System;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using ConwaysGameOfLife;

namespace ConwaysGameOfLife
{
    public class GameOfLife
    {
        private GridFormatter GridFormatter { get; }
        private MessageHandler MessageHandler { get; }
        private IWorld World { get; set; }
        private StateGenerator StateGenerator { get; }
        
        public GameOfLife(IInputReader inputReader, IOutputWriter outputWriter)
        {   
            StateGenerator = new StateGenerator();
            var inputProcessor = new InputProcessor(inputReader);
            GridFormatter = new GridFormatter();
            MessageHandler = new MessageHandler(outputWriter);
            
            World = inputProcessor.GetWorld();

            
            InitializeGame();
        }

        private void InitializeGame()
        {

            DisplayInitialGameOutput();
        }

        private void DisplayInitialGameOutput()
        {
            DisplayWorldState();
            MessageHandler.DisplayGameGuide();
        }

        public void Step()
        {
            World = StateGenerator.GetNextState(World);
            
            DisplayWorldState();
        }

        private void DisplayWorldState()
        {
            var formattedWorld = GridFormatter.Format(World);
            MessageHandler.DisplayFormattedGrid(formattedWorld);
        }
    }
}