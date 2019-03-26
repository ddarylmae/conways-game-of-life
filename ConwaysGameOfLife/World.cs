namespace ConwaysGameOfLife
{
    public class World
    {
        private bool[] _grid;

        public World(Area area)
        {
            InitialiseWorld(area);
        }

        private void InitialiseWorld(Area area)
        {
            var gridSize = area.Length * area.Width;
            _grid = new bool[gridSize];
        }
        
        public int GetSize()
        {
            return _grid.Length;
        }
    }
}