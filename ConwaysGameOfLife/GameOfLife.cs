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
        
        public GameOfLife()
        {
            InputProcessor = new InputProcessor();
        }
        
        public string GetNewState(string initialState)
        {
            World = InputProcessor.GetInitialWorldState(initialState);

            World.Evolve();

            return World.GetFormattedGrid();

        }
    }
}