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

        public List<Cell> GetNeighboursOfCellAt(Coordinate coordinate)
        {
            var neighbours = new List<Cell>();
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
                neighbours.Add(GetCellAt(new Coordinate(rowIndex, columnIndex)));
            }

            return neighbours;
        }
        
        public void InitialiseWorld(string initialState)
        {
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
        }

        public Cell GetCellAt(Coordinate coordinate)
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

        public void UpdateCellAt(Coordinate coordinate, Cell cell)
        {
            Grid[coordinate.Row, coordinate.Column] = cell;
        }
    }
}