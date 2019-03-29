using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using ConwaysGameOfLife;

namespace ConwaysGameOfLife
{
    public class GameOfLife
    {
        private InputProcessor InputProcessor { get; set; }
        public GameOfLife()
        {
            InputProcessor = new InputProcessor();
        }
        
        public string GetNewState(string initialState)
        {
            var world = InputProcessor.GetGrid(initialState);
            
            var neighbours = new List<bool>
            {
                {world[0,0]},
                {world[0,1]},
                {world[0,2]},
                {world[1,0]},
                {world[1,2]},
                {world[2,0]},
                {world[2,1]},
                {world[2,2]},
            };
            
            var liveNeighbourCount = neighbours.Count(x => x);
            var currentCell = liveNeighbourCount > 1 && liveNeighbourCount < 4 ? '#' : ' ';  
            
            return "   \n" +
                   $" {currentCell} \n" +
                   "   ";
        }
    }

    public class Dimensions
    {
        public int Length { get; set; }
        public int Width { get; set; }
    }

    public class InputProcessor
    {
        public bool[,] GetGrid(string initialState)
        {
            var dimensionString = GetFirstLineFromInput(initialState);

            var gridContent = GetInitialGridFromInput(initialState, dimensionString);

            var dimensions = GetDimensions(initialState);
            
            var grid = CreateGrid(dimensions, gridContent);

            return grid;
        }
        
        private Dimensions GetDimensions(string input)
        {
            var dimensionInput = GetFirstLineFromInput(input);
            if (TryParseDimensions(dimensionInput, out var length, out var width))
            {
                return new Dimensions
                {
                    Length = length, 
                    Width = width
                };
            }

            return null;
        }
        
        private bool[,] CreateGrid(Dimensions dimensions, string[] gridContent)
        {
            var grid = new bool[dimensions.Length, dimensions.Width];
            for (int rowIndex = 0; rowIndex < dimensions.Length; rowIndex++)
            {
                var currentRowInput = gridContent[rowIndex];
                for (int colIndex = 0; colIndex < dimensions.Width; colIndex++)
                {
                    grid[rowIndex, colIndex] = currentRowInput[colIndex] == '#';
                }
            }

            return grid;
        }

        private string[] GetInitialGridFromInput(string initialState, string dimensionInput)
        {
            return initialState.Remove(0,dimensionInput.Length+1).Split('\n');
        }

        private string GetFirstLineFromInput(string input)
        {
            return input.Split('\n')[0];
        }

        private bool TryParseDimensions(string dimensions, out int length, out int width)
        {
            width = 0;
            var dimensionItems = dimensions.Split(',');           
            
            return int.TryParse(dimensionItems[0], out length) && int.TryParse(dimensionItems[1], out width);
        }
    }
}