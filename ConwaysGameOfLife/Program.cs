using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GameOfLife game = new GameOfLife(
                new OutputWriter(), 
                new TextFileReader());
            
            game.Start();
        }
    }
}