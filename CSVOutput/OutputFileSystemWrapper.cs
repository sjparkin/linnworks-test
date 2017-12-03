using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVOutputPlugin
{
    public class OutputFileSystemWrapper : IOutputFileSystem
    {
        public OutputFileSystemWrapper(string outputLocation)
        {
            _outputLocation = outputLocation;
        }

        public void WriteFile(string[] fileContents, string fileName)
        {
            File.WriteAllLines(Path.Combine(_outputLocation, fileName), fileContents);
        }

        private string _outputLocation;

              
    }
}
