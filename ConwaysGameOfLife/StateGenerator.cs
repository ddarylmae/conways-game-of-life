using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class StateGenerator
    {
        public IWorld GetNextState(IWorld world)
        {
            var liveCells = GetNextGenerationLiveCells(world);
            
            return new World(world.GetDimensions(), liveCells);
        }

        private List<Coordinate> GetNextGenerationLiveCells(IWorld world)
        {
            var liveCells = new List<Coordinate>();

            var dimensions = world.GetDimensions();

            for (int row = 0; row < dimensions.Width; row++)
            {
                for (int column = 0; column < dimensions.Length; column++)
                {
                    var currentCoordinate = new Coordinate(row, column);
                    var newCellState = GetNewCellState(currentCoordinate, world);
                    
                    if (newCellState == Cell.Live)
                    {
                        liveCells.Add(currentCoordinate);
                    }
                }
            }

            return liveCells;
        }
        
        private Cell GetNewCellState(Coordinate coordinate, IWorld world)
        {
            var currentCell = world.GetCellAt(coordinate);
            var neighbours = world.GetNeighboursOfCellAt(coordinate);
            var liveNeighbors = neighbours.Count(neighbour => neighbour == Cell.Live);
            
            if (liveNeighbors == 3 || currentCell == Cell.Live && liveNeighbors == 2)
            {
                return Cell.Live;
            }

            return Cell.Dead;
        }
    }
}