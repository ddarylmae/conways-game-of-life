using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class StateGenerator
    {
        public IWorld GetNextState(IWorld world)
        {
            var livingCells = GetLivingCells(world);
            
            return new World(world.GetDimensions(), livingCells);
        }

        private List<Coordinate> GetLivingCells(IWorld world)
        {
            var liveCells = new List<Coordinate>();

            var dimensions = world.GetDimensions();

            for (int row = 0; row < dimensions.Width; row++)
            {
                for (int column = 0; column < dimensions.Length; column++)
                {
                    var currentCoordinate = new Coordinate(row, column);
                    var currentCell = world.GetCellAt(currentCoordinate);

                    var neighbours = world.GetNeighboursOfCellAt(currentCoordinate);

                    var newCell = GetNewCellState(neighbours, currentCell);
                    if (newCell == Cell.Live)
                    {
                        liveCells.Add(currentCoordinate);
                    }
                }
            }

            return liveCells;
        }

        private Cell GetNewCellState(List<Cell> neighbours, Cell currentCell)
        {
            var liveNeighbors = neighbours.Count(neighbour => neighbour == Cell.Live);
            
            if (liveNeighbors == 3 || currentCell == Cell.Live && liveNeighbors == 2)
            {
                return Cell.Live;
            }

            return Cell.Dead;
        }
    }
}