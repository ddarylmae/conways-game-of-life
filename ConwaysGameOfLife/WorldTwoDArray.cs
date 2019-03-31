using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class WorldTwoDArray : IWorld
    {
        public Cell[,] Grid { get; set; }

        public List<Coordinate> GetNeighbouringCells(Coordinate coordinate)
        {
            var neighbours = new List<Coordinate>();
            var neighbourOffset = new List<Coordinate>
            {
                new Coordinate {Row = -1, Column = -1}, 
                new Coordinate {Row = -1, Column = 0},
                new Coordinate {Row = -1, Column = 1},
                new Coordinate {Row = 0, Column = -1},
                new Coordinate {Row = 0, Column = 1},
                new Coordinate {Row = 1, Column = -1},
                new Coordinate {Row = 1, Column = 0},
                new Coordinate {Row = 1, Column = 1},
            };

            foreach (var offset in neighbourOffset)
            {
                var rowIndex = (coordinate.Row + offset.Row + GetGridWidth()) % GetGridWidth();
                var columnIndex = (coordinate.Column + offset.Column + GetGridLength()) % GetGridLength();
                neighbours.Add(new Coordinate {Row = rowIndex, Column = columnIndex});
            }

            return neighbours;
        }

        public Cell GetElementAt(Coordinate coordinate)
        {
            return null;
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
                    var neighbours = GetNeighbouringCells(new Coordinate {Row = row, Column = column});
                    var liveCellCount = neighbours.Count(cell => Grid[cell.Row, cell.Column].IsLive);
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