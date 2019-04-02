using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class StateGenerator
    {
        public IWorld GetNextWorldState(IWorld world)
        {
            var updatedCells = GetUpdatedCells(world);

            world = UpdateWorldState(world, updatedCells);
            
            return world;
        }

        private Dictionary<Coordinate, Cell> GetUpdatedCells(IWorld world)
        {
            var updatedCells = new Dictionary<Coordinate, Cell>();
            
            var dimensions = world.GetDimensions();

            for (int row = 0; row < dimensions.Width; row++)
            {
                for (int column = 0; column < dimensions.Length; column++)
                {
                    var currentCoordinate = new Coordinate(row, column);
                    var currentCell = world.GetCellAt(currentCoordinate);

                    var neighbours = world.GetNeighboursOfCellAt(currentCoordinate);

                    var newCell = GetNewCellState(neighbours, currentCell);

                    if (IsCellStateChanged(currentCell, newCell))
                    {
                        updatedCells.Add(currentCoordinate, newCell);
                    }
                }
            }

            return updatedCells;
        }

        private bool IsCellStateChanged(Cell oldCell, Cell newCell)
        {
            return oldCell.IsLive != newCell.IsLive;
        }

        private IWorld UpdateWorldState(IWorld world, Dictionary<Coordinate,Cell> updatedCells)
        {
            foreach (var cell in updatedCells)
            {
                var coordinate = cell.Key;
                var newState = cell.Value;
                
                world.UpdateCellAt(coordinate, newState);
            }

            return world;
        }

        private Cell GetNewCellState(List<Cell> neighbours, Cell currentCell)
        {
            var liveNeighbors = neighbours.Count(neighbour => neighbour.IsLive);
            
            var cell = new Cell();
            
            if (liveNeighbors == 3 || currentCell.IsLive && liveNeighbors == 2)
            {
                cell.IsLive = true;
            }

            return cell;
        }
    }
}