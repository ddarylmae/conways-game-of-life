using System.Linq;
using ConwaysGameOfLife;

namespace ConwaysGameOfLife
{
    public class GameOfLife
    {
        public GameOfLife()
        {
            
        }
        
        public string GetNewState(string currentState)
        {
            var lines = currentState.Split('\n');
            
            var cell = lines[1][1].ToString();
            
            if (cell == "#" && GetLiveNeighboursCount(currentState) > 2 && GetLiveNeighboursCount(currentState) < 5)
            {
                return "#";
            }

            return " ";
        }

        private int GetLiveNeighboursCount(string currentState)
        {
            return currentState.Count(c => c == '#');
        }
    }
}