namespace ConwaysGameOfLife
{
    public class GridFormatter
    {
        public string Format(IWorld world)
        {
            var grid = "";
            var dimensions = world.GetDimensions();
            
            for (int row = 0; row < dimensions.Width; row++)
            {
                for (int column = 0; column < dimensions.Length; column++)
                {
                    grid += world.GetCellAt(new Coordinate(row, column)) == Cell.Live ? Constants.LiveCell : Constants.DeadCell;
                }

                grid += "\n";
            }

            return grid;
        }
    }
}