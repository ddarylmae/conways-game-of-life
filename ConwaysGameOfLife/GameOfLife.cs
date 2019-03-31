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
        private WorldTwoDArray World { get; set; }
        
        private IOutputWriter OutputWriter { get; set; }
        
        public GameOfLife(IOutputWriter outputWriter)
        {
            OutputWriter = outputWriter;
            InputProcessor = new InputProcessor();
        }
        
        public void SetInitialState(string initialState)
        {
            World = InputProcessor.GetInitialWorldState(initialState);

            World.Evolve();
            
            DisplayCurrentState();
        }

        private void DisplayCurrentState()
        {
            OutputWriter.Write(World.GetFormattedGrid());
        }
    }
}