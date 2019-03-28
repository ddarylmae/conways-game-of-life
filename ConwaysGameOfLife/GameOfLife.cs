using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ConwaysGameOfLife;

namespace ConwaysGameOfLife
{
    public class GameOfLife
    {   
        public GameOfLife()
        {
            
        }
        
        public string GetNewState(string currentState)
        {
            // process input string by adding model and setting it to grid 
            // set new grid state
            // update grid state
            // create list of neighbours for cell
            // count neighbours
            
            var lines = currentState.Split('\n');
            
            var dimensions = lines[0];
            var dimensionItems = dimensions.Split(',');
            var row = int.Parse(dimensionItems[0]);
            var col = int.Parse(dimensionItems[1]);
            
            var gridContent = currentState.Remove(0,dimensions.Length+1);
            var onlyGridContent = gridContent.Split('\n');
            
            // get neighbours from "normal" cells, cells with surrounding neighbours not out of range
           
            var updatedGrid = InitialiseGridFromInput(row, col, onlyGridContent);
            
            var neighbours = new List<bool>
            {
                {updatedGrid[0,0]},
                {updatedGrid[0,1]},
                {updatedGrid[0,2]},
                {updatedGrid[1,0]},
                {updatedGrid[1,2]},
                {updatedGrid[2,0]},
                {updatedGrid[2,1]},
                {updatedGrid[2,2]},
            };
            
            var liveNeighbourCount = neighbours.Count(x => x);
            var currentCell = liveNeighbourCount > 1 && liveNeighbourCount < 4 ? '#' : ' ';  
            
            return "   \n" +
                   $" {currentCell} \n" +
                   "   ";
        }

        private bool[,] InitialiseGridFromInput(int row, int col, string[] gridContent)
        {
            var grid = new bool[row, col];
            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                var currentRowInput = gridContent[rowIndex];
                for (int colIndex = 0; colIndex < col; colIndex++)
                {
                    grid[rowIndex, colIndex] = currentRowInput[colIndex] == '#';
                }
            }

            return grid;
        }
    }
}