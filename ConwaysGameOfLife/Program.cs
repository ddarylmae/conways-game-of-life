using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            
            GameOfLife game = new GameOfLife(new TextFileReader(), new OutputWriter());

            while (input!="q")
            {
                input = Console.ReadLine();
                game.Step();
            }
        }
    }
}