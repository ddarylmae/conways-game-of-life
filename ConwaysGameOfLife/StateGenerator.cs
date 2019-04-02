using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class StateGenerator : IStateGenerator
    {
        public IWorld Evolve(IWorld currentWorld)
        {
            var dimensions = currentWorld.GetDimensions();
            var nextGenerationWorld = new World(dimensions); 
            
            for (int row = 0; row < dimensions.Width; row++)
            {
                for (int column = 0; column < dimensions.Length; column++)
                {
                    var currentCoordinate = new Coordinate(row, column);
                    
                    var neighbours = currentWorld.GetNeighbouringCells(currentCoordinate);
                    
                    var newState = GetNewCellState(currentWorld, neighbours, currentCoordinate);

                    nextGenerationWorld.UpdateCell(currentCoordinate, newState);
                }
            }

            return nextGenerationWorld;
        }

        private Cell GetNewCellState(IWorld world, List<Coordinate> neighbours, Coordinate currentCoordinate)
        {
            var liveCellCount = neighbours.Count(coordinate => world.GetCellAt(coordinate).IsLive);
            
            var cell = new Cell();
            
            if (liveCellCount < 2 || liveCellCount > 3)
            {
                cell.IsLive = false;
            }
            else if (liveCellCount == 3 || world.GetCellAt(currentCoordinate).IsLive && liveCellCount == 2)
            {
                cell.IsLive = true;
            }

            return cell;
        }
    }
}