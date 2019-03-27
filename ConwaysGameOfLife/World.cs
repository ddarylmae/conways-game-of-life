namespace ConwaysGameOfLife
{
    public class World
    {
        private bool[,] _grid;

        public World(Area area)
        {
            InitialiseWorld(area);
        }

        private void InitialiseWorld(Area area)
        {
            _grid = new bool[area.Length,area.Width];
        }
        
        public int GetSize()
        {
            return _grid.Length;
        }
    }
}