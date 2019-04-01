using System;
using System.IO;

namespace ConwaysGameOfLife
{
    public class TextFileReader : IInputReader
    {
        private const string FilePath = "..//initial-state-15X25.txt";
        
        public string GetStringContent()
        {
            try
            {
                using (var streamReader = new StreamReader(FilePath))
                {
                    var fileContent = streamReader.ReadToEnd();
                    return fileContent;
                }
            }
            catch (IOException e)
            {
                
            }
            
            return "";
        }
    }
}