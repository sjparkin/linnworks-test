using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVOutputPlugin
{
    public interface IOutputFileSystem
    {
        void WriteFile(string[] fileContents, string fileName);
    }
}
