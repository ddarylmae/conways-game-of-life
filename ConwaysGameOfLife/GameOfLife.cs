using System.Linq;
using ConwaysGameOfLife;

namespace ConwaysGameOfLife
{
    public class GameOfLife
    {
        public GameOfLife()
        {
            
        }
        
        public CellState GetNewState(string currentState)
        {
            var lines = currentState.Split('\n');
            
            var cellValue = lines[1][1].ToString();
            
            if (cellValue == "#" && GetLiveNeighboursCount(currentState) > 2 && GetLiveNeighboursCount(currentState) < 5)
            {
                return CellState.Live;
            }

            return CellState.Dead;
        }

        private int GetLiveNeighboursCount(string currentState)
        {
            return currentState.Count(c => c == '#');
        }
    }
}