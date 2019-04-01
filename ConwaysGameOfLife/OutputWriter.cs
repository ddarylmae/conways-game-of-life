using System;

namespace ConwaysGameOfLife
{
    public class OutputWriter : IOutputWriter
    {
        public void Write(string message)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(message);
        }
    }
}