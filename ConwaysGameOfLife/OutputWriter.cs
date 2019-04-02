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
    }
}