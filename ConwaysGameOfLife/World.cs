using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class World : IWorld
    {
        private Cell[,] Grid { get; }

        public World(Dimensions dimensions)
        {
            Grid = new Cell[dimensions.Width, dimensions.Length];
        }

        public List<Cell> GetNeighboursOfCellAt(Coordinate coordinate)
        {
            var neighbours = new List<Cell>();
            var neighbourOffsets = new List<Coordinate>
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

            foreach (var offset in neighbourOffsets)
            {
                var rowIndex = GetIndexFromOffSet(coordinate.Row, offset.Row, RowCount());
                var columnIndex = GetIndexFromOffSet(coordinate.Column, offset.Column, ColumnCount());
                
                neighbours.Add(GetCellAt(new Coordinate(rowIndex, columnIndex)));
            }

            return neighbours;
        }

        private int GetIndexFromOffSet(int position, int offset, int boundary)
        {
            return (position + offset + boundary) % boundary;
        }
        
        public void SetWorld(string initialState)
        {
            var initialStateLines = initialState.Split('\n');
            for (int rowIndex = 0; rowIndex < RowCount(); rowIndex++)
            {
                var currentRowInput = initialStateLines[rowIndex];
                for (int colIndex = 0; colIndex < ColumnCount(); colIndex++)
                {
                    var cell = new Cell
                    {
                        IsLive = currentRowInput[colIndex] == Constants.LiveCell
                    };
                    
                    Grid[rowIndex, colIndex] = cell;
                }
            }
        }

        public Cell GetCellAt(Coordinate coordinate)
        {
            return Grid[coordinate.Row, coordinate.Column];
        }

        private int ColumnCount()
        {
            return Grid.GetLength(1);
        }

        private int RowCount()
        {
            return Grid.GetLength(0);
        }

        public Dimensions GetDimensions()
        {
            return new Dimensions
            {
                Width = RowCount(),
                Length = ColumnCount()
            };
        }

        public void UpdateCellAt(Coordinate coordinate, Cell cell)
        {
            Grid[coordinate.Row, coordinate.Column] = cell;
        }
    }
}