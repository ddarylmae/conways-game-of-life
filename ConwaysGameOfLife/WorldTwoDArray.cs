using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class WorldTwoDArray
    {
        public Cell[,] Grid { get; set; }
        
        private HashSet<Coordinate> GetNeighboursOfCoordinate(Coordinate coordinate)
        {
            var neighbours = new HashSet<Coordinate>();
            var neighbourOffset = new List<Coordinate>
            {
                new Coordinate {X = -1, Y = -1}, 
                new Coordinate {X = -1, Y = 0},
                new Coordinate {X = -1, Y = 1},
                new Coordinate {X = 0, Y = -1},
                new Coordinate {X = 0, Y = 1},
                new Coordinate {X = 1, Y = -1},
                new Coordinate {X = 1, Y = 0},
                new Coordinate {X = 1, Y = 1},
            };

            foreach (var offset in neighbourOffset)
            {
                var rowIndex = (coordinate.X + offset.X + GetGridWidth()) % GetGridWidth();
                var columnIndex = (coordinate.Y + offset.Y + GetGridLength()) % GetGridLength();
                neighbours.Add(new Coordinate {X = rowIndex, Y = columnIndex});
            }

            return neighbours;
        }

        private int GetGridLength()
        {
            return Grid.GetLength(1);
        }

        private int GetGridWidth()
        {
            return Grid.GetLength(0);
        }

        public void Evolve()
        {
            Cell[,] newGridState = new Cell[GetGridLength(),GetGridWidth()];
            for (int row = 0; row < GetGridWidth(); row++)
            {
                for (int column = 0; column < GetGridLength(); column++)
                {
                    var neighbours = GetNeighboursOfCoordinate(new Coordinate {X = row, Y = column});
                    var liveCellCount = neighbours.Count(cell => Grid[cell.X, cell.Y].IsLive);
                    var newState = new Cell
                    {
                        IsLive = false
                    };
                    if (liveCellCount < 2 || liveCellCount > 3)
                    {
                        newState.IsLive = false;
                    }
                    else if (liveCellCount == 3 || Grid[row, column].IsLive && liveCellCount == 2)
                    {
                        newState.IsLive = true;
                    }
                    newGridState[row, column] = newState;
                }
            }

            Grid = newGridState;
        }

        public string GetFormattedGrid()
        {
            var grid = "";
            for (int width = 0; width < GetGridWidth(); width++)
            {
                for (int length = 0; length < GetGridLength(); length++)
                {
                    grid += Grid[width, length].IsLive ? "#" : " ";
                }

                grid += "\n";
            }

            return grid;
        }
    }
}