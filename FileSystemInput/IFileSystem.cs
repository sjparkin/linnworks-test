using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemInputPlugin
{
    public interface IFileSystem
    {
        string[] GetAllFiles();

        string ReadFile(string filePath);
        void ArchiveFile(string fileName);
    }
}
