namespace ConwaysGameOfLife
{
    public class InputProcessor
    {
        public WorldArray SetInitialWorldState(string initialState)
        {
            var dimensionString = GetFirstLineFromInput(initialState);

            var gridContent = GetInitialGridFromInput(initialState, dimensionString);

            var dimensions = GetDimensions(initialState);
            
            var world = CreateWorld(dimensions, gridContent);

            return world;
        }
        
        private Dimensions GetDimensions(string input)
        {
            var dimensionInput = GetFirstLineFromInput(input);
            
            if (TryParseDimensions(dimensionInput, out var length, out var width))
            {
                return new Dimensions
                {
                    Length = length, 
                    Width = width
                };
            }

            return null;
        }
        
        private WorldArray CreateWorld(Dimensions dimensions, string[] initialState)
        {
            var grid = new Cell[dimensions.Length, dimensions.Width];
            
            for (int rowIndex = 0; rowIndex < dimensions.Length; rowIndex++)
            {
                var currentRowInput = initialState[rowIndex];
                for (int colIndex = 0; colIndex < dimensions.Width; colIndex++)
                {
                    var cell = new Cell
                    {
                        IsLive = currentRowInput[colIndex] == '#'
                    };
                    
                    grid[rowIndex, colIndex] = cell;
                }
            }

            var finalGrid = new WorldArray
            {
                Grid = grid
            };

            return finalGrid;
        }

        private string[] GetInitialGridFromInput(string initialState, string dimensionInput)
        {
            return initialState.Remove(0,dimensionInput.Length+1).Split('\n');
        }

        private string GetFirstLineFromInput(string input)
        {
            return input.Split('\n')[0];
        }

        private bool TryParseDimensions(string dimensions, out int length, out int width)
        {
            width = 0;
            var dimensionItems = dimensions.Split(',');           
            
            return int.TryParse(dimensionItems[0], out length) && int.TryParse(dimensionItems[1], out width);
        }
    }
}