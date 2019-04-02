using System;
using System.IO;

namespace ConwaysGameOfLife
{
    public class TextFileReader : IInputReader
    {
        public string GetStringContent()
        {
            var filePath = Constants.TextFilePath;
            try
            {
                using (var streamReader = new StreamReader(filePath))
                {
                    var fileContent = streamReader.ReadToEnd();
                    return fileContent;
                }
            }
            catch (IOException exception)
            {
                
            }
            
            return "";
        }
    }
}