namespace ConwaysGameOfLife
{
    public class InputProcessor
    {
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