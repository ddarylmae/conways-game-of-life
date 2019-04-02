using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public interface IWorld
    {
        List<Cell> GetNeighboursOfCellAt(Coordinate coordinate);
        Cell GetCellAt(Coordinate coordinate);
        Dimensions GetDimensions();
        void UpdateCellAt(Coordinate coordinate, Cell cell);
        void SetWorld(string initialState);
    }
}