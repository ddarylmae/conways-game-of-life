using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public interface IWorld
    {
        List<Coordinate> GetNeighbouringCells(Coordinate coordinate);
        Cell GetElementAt(Coordinate coordinate);
    }
}