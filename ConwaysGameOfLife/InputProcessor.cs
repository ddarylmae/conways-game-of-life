namespace ConwaysGameOfLife
{
    public class InputProcessor
    {
//        public IWorld SetInitialWorldState(string initialState)
//        {
//            var dimensionString = GetFirstLineFromInput(initialState);
//
//            var gridContent = GetInitialGridFromInput(initialState, dimensionString);
//
//            var dimensions = GetDimensions(initialState);
//            
//            var world = new World(dimensions);
//            world.InitialiseWorld(gridContent);
//
//            return world;
//        }
        
        public Dimensions GetDimensions(string input)
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
        
//        private World CreateWorld(Dimensions dimensions, string[] initialState)
//        {
//            var grid = new Cell[dimensions.Length, dimensions.Width];
//            
//            for (int rowIndex = 0; rowIndex < dimensions.Length; rowIndex++)
//            {
//                var currentRowInput = initialState[rowIndex];
//                for (int colIndex = 0; colIndex < dimensions.Width; colIndex++)
//                {
//                    var cell = new Cell
//                    {
//                        IsLive = currentRowInput[colIndex] == '#'
//                    };
//                    
//                    grid[rowIndex, colIndex] = cell;
//                }
//            }
//
//            var finalGrid = new World
//            {
//                Grid = grid
//            };
//
//            return finalGrid;
//        }

        public string GetInitialGridFromInput(string initialState)
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