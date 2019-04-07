using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class InputProcessor
    {
        private readonly IInputReader _inputReader;

        public InputProcessor(IInputReader reader)
        {
            _inputReader = reader;
        }
        
        private Dimensions GetDimensions(string input)
        {
            var dimensionInput = GetFirstLineFromInput(input);
            
            if (TryParseDimensions(dimensionInput, out var width, out var length))
            {
                return new Dimensions
                {
                    Length = length, 
                    Width = width
                };
            }

            return null;
        }

        public World GetWorld()
        {
            var input = _inputReader.GetStringContent();
            var dimensions = GetDimensions(input);
            var livingCells = GetLivingCells(input);

            return new World(dimensions, livingCells);

        }

        private List<Coordinate> GetLivingCells(string input)
        {
            var liveCells = new List<Coordinate>();
            var dimensions = GetDimensions(input);
            var grid = GetInitialGridFromInput(input);

            var gridLines = grid.Split('\n');
            for (int row = 0; row < dimensions.Width; row++)
            {
                var currentGridRow = gridLines[row];
                for (int column = 0; column < dimensions.Length; column++)
                {
                    if (currentGridRow[column] == Constants.LiveCell)
                    {
                        liveCells.Add(new Coordinate(row, column));
                    }
                }
            }

            return liveCells;
        }

        private string GetInitialGridFromInput(string initialState)
        {
            var dimensionInput = GetFirstLineFromInput(initialState);
            return initialState.Remove(0,dimensionInput.Length+1);
        }

        private string GetFirstLineFromInput(string input)
        {
            return input.Split('\n')[0];
        }

        private bool TryParseDimensions(string dimensions, out int width, out int length)
        {
            length = 0;
            var dimensionItems = dimensions.Split(',');           
            
            return int.TryParse(dimensionItems[0], out width) && int.TryParse(dimensionItems[1], out length);
        }
    }
}