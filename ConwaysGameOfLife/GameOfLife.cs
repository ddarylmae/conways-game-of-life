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
        private InputProcessor InputProcessor { get; }
        private MessageHandler MessageHandler { get; }
        private IInputReader InputReader { get; }
        private IWorld World { get; set; }
        private StateGenerator StateGenerator { get; }
        
        public GameOfLife(IInputReader inputReader, IOutputWriter outputWriter)
        {
            InputReader = inputReader;
            
            StateGenerator = new StateGenerator();
            InputProcessor = new InputProcessor();
            GridFormatter = new GridFormatter();
            MessageHandler = new MessageHandler(outputWriter);
            
            InitializeGame();
        }

        private void InitializeGame()
        {
            var initialState = InputReader.GetStringContent();
            World = new World(InputProcessor.GetDimensions(initialState));
            World.SetWorld(InputProcessor.GetInitialGridFromInput(initialState));

            DisplayInitialGameOutput();
        }

        private void DisplayInitialGameOutput()
        {
            DisplayWorldState();
            MessageHandler.DisplayGameGuide();
        }

        public void Step()
        {
            World = StateGenerator.GetNextWorldState(World);
            
            DisplayWorldState();
        }

        private void DisplayWorldState()
        {
            var formattedWorld = GridFormatter.Format(World);
            MessageHandler.DisplayFormattedGrid(formattedWorld);
        }
    }
}