using System;

namespace ConwaysGameOfLife
{
    public class OutputWriter : IOutputWriter
    {
        public void WriteAtTop(string formattedWorld)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(formattedWorld);
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}