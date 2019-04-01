using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            
            GameOfLife game = new GameOfLife(
                new OutputWriter(), 
                new TextFileReader());

            while (input!="q")
            {
                game.Step();
                input = Console.ReadLine();
            }
        }
    }
}