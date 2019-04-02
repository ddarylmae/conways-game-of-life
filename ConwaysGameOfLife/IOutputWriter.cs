namespace ConwaysGameOfLife
{
    public interface IOutputWriter
    {
        void WriteAtTop(string formattedWorld);
        void Write(string message);
    }
}