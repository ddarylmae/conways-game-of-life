using System;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class StateGenerator : IStateGenerator
    {
        public IWorld Evolve(IWorld world)
        {
            var dimensions = world.GetDimensions();
            var newGridState = new World(dimensions); 
            
            for (int row = 0; row < dimensions.Width; row++)
            {
                for (int column = 0; column < dimensions.Length; column++)
                {
                    var neighbours = world.GetNeighbouringCells(new Coordinate(row, column));
//                    var liveCellCount = neighbours.Count(cell => Grid[cell.Row, cell.Column].IsLive);
                    var liveCellCount = neighbours.Count(neighbour => world.GetElementAt(new Coordinate(neighbour.Row, neighbour.Column)).IsLive);
                    var newState = new Cell
                    {
                        IsLive = false
                    };
                    if (liveCellCount < 2 || liveCellCount > 3)
                    {
                        newState.IsLive = false;
                    }
//                    else if (liveCellCount == 3 || Grid[row, column].IsLive && liveCellCount == 2)
                    else if (liveCellCount == 3 || world.GetElementAt(new Coordinate(row, column)).IsLive && liveCellCount == 2)
                    {
                        newState.IsLive = true;
                    }
                    
                    newGridState.UpdateCell(new Coordinate(row, column), newState);
//                    newGridState[row, column] = newState;
                }
            }

            return newGridState;
        }
    }
}