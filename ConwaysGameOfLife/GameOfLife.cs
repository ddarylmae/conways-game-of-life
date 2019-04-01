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
        private bool IsGameStarted { get; set; }
        
        public GameOfLife(IOutputWriter outputWriter, IInputReader inputReader)
        {
            OutputWriter = outputWriter;
            InputReader = inputReader;
            
            InputProcessor = new InputProcessor();
            IsGameStarted = false;
        }

        private void InitializeGame()
        {
            var initialState = InputReader.GetStringContent();
            
            World = InputProcessor.SetInitialWorldState(initialState);
        }

        public void Step()
        {
            if (!IsGameStarted)
            {
                InitializeGame();
                IsGameStarted = true;
            }
            else
            {
                World.Evolve();
            }
            
            DisplayWorldState();
        }

        private void DisplayWorldState()
        {
            OutputWriter.Write(World.GetFormattedGrid());
        }
    }
}