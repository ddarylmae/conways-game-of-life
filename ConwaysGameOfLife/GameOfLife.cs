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
        private WorldTwoDArray World { get; set; }
        private IOutputWriter OutputWriter { get; set; }
        
        public GameOfLife(IOutputWriter outputWriter, IInputReader inputReader)
        {
            OutputWriter = outputWriter;
            InputProcessor = new InputProcessor();
            InputReader = inputReader;
        }
        
        public void Start()
        {
            var initialState = InputReader.GetStringContent(); // file input processor here
            
            World = InputProcessor.SetInitialWorldState(initialState);

            World.Evolve();
            
            DisplayCurrentState();
        }

        private void DisplayCurrentState()
        {
            OutputWriter.Write(World.GetFormattedGrid());
        }
    }
}