using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public interface IWorld
    {
        List<Coordinate> GetNeighbouringCells(Coordinate coordinate);
        Cell GetElementAt(Coordinate coordinate);
        void Evolve();
        string GetFormattedGrid();
        Dimensions GetDimensions();
        void UpdateCell(Coordinate coordinate, Cell cell);
        void InitialiseWorld(string initialState);
    }
}