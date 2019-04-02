namespace ConwaysGameOfLife
{
    public class GridFormatter
    {
        public string Format(IWorld world)
        {
            var dimensions = world.GetDimensions();
            var grid = "";
            
            for (int row = 0; row < dimensions.Width; row++)
            {
                for (int column = 0; column < dimensions.Length; column++)
                {
                    var coordinate = new Coordinate(row, column);
                    
                    grid += world.GetCellAt(coordinate).IsLive ? Constants.LiveCell : Constants.DeadCell;
                }

                grid += "\n";
            }

            return grid;
        }
    }
}