using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class World : IWorld
    {
        private Cell[,] Grid { get; set; }

        public World(Dimensions dimensions)
        {
            Grid = new Cell[dimensions.Width, dimensions.Length];
        }

        public List<Coordinate> GetNeighbouringCells(Coordinate coordinate)
        {
            var neighbours = new List<Coordinate>();
            var neighbourOffset = new List<Coordinate>
            {
                new Coordinate(-1, -1), 
                new Coordinate(-1, 0),
                new Coordinate(-1, 1),
                new Coordinate(0, -1),
                new Coordinate(0, 1),
                new Coordinate(1, -1),
                new Coordinate(1, 0),
                new Coordinate(1, 1),
            };

            foreach (var offset in neighbourOffset)
            {
                var rowIndex = (coordinate.Row + offset.Row + GetGridWidth()) % GetGridWidth();
                var columnIndex = (coordinate.Column + offset.Column + GetGridLength()) % GetGridLength();
                neighbours.Add(new Coordinate(rowIndex, columnIndex));
            }

            return neighbours;
        }
        
        public void InitialiseWorld(string initialState)
        {
//            var grid = new Cell[dimensions.Length, dimensions.Width];
            var initialStateLines = initialState.Split('\n');
            for (int rowIndex = 0; rowIndex < GetGridWidth(); rowIndex++)
            {
                var currentRowInput = initialStateLines[rowIndex];
                for (int colIndex = 0; colIndex < GetGridLength(); colIndex++)
                {
                    var cell = new Cell
                    {
                        IsLive = currentRowInput[colIndex] == '#'
                    };
                    
                    Grid[rowIndex, colIndex] = cell;
                }
            }

//            Grid = grid;
        }

        public Cell GetElementAt(Coordinate coordinate)
        {
            return Grid[coordinate.Row, coordinate.Column];
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
            Cell[,] newGridState = new Cell[GetGridWidth(),GetGridLength()];
            
            for (int row = 0; row < GetGridWidth(); row++)
            {
                for (int column = 0; column < GetGridLength(); column++)
                {
                    var neighbours = GetNeighbouringCells(new Coordinate(row, column));
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

        public Dimensions GetDimensions()
        {
            return new Dimensions
            {
                Width = GetGridWidth(),
                Length = GetGridLength()
            };
        }

        public void UpdateCell(Coordinate coordinate, Cell cell)
        {
            Grid[coordinate.Row, coordinate.Column] = cell;
        }
    }
}