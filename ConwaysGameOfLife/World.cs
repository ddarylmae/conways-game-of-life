using System.Diagnostics;

namespace ConwaysGameOfLife
{
    public class World
    {
        private bool[] Grid;

        public World(string dimensionInput)
        {
            InitialiseWorldFromSizeInput(dimensionInput);
        }

        public void InitialiseWorldFromSizeInput(string dimensionInput)
        {
            var dimensions = dimensionInput.Split('X');
            var length = dimensions[0];
            var width = dimensions[1];

            var gridSize = int.Parse(length) * int.Parse(width);
            Grid = new bool[gridSize];
        }
        
        public int GetSize()
        {
            return Grid.Length;
        }
    }
}