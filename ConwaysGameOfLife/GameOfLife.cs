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
            
            if (cell == "#" && currentState.Count(c => c == '#') > 2)
            {
                return "#";
            }

            return " ";
        }
    }
}