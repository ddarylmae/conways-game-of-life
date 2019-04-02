using System;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using ConwaysGameOfLife;

namespace ConwaysGameOfLife
{
    public class GameOfLife
    {
        private InputProcessor InputProcessor { get; set; }
        private IInputReader InputReader { get; set; }
        private IWorld World { get; set; }
        private IOutputWriter OutputWriter { get; set; }
        private IStateGenerator StateGenerator;
        
        public GameOfLife(IOutputWriter outputWriter, IInputReader inputReader)
        {
            OutputWriter = outputWriter;
            InputReader = inputReader;
            
            InputProcessor = new InputProcessor();
            StateGenerator = new StateGenerator();
            
            InitializeGame();
        }

        private void InitializeGame()
        {
            var initialState = InputReader.GetStringContent();
//            World = InputProcessor.SetInitialWorldState(initialState);
            World = new World(InputProcessor.GetDimensions(initialState));
            World.InitialiseWorld(InputProcessor.GetInitialGridFromInput(initialState));
            DisplayWorldState();
        }

        public void Step()
        {
            World = StateGenerator.Evolve(World);
//            World.Evolve();
            DisplayWorldState();
        }

        private void DisplayWorldState()
        {
            OutputWriter.Write(World.GetFormattedGrid());
        }
    }
}