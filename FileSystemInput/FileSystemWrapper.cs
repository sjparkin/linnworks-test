using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemInputPlugin
{
    public class FileSystemWrapper : IFileSystem
    {
        public FileSystemWrapper(string inputLocation, string archiveLocation)
        {
            _inputLocation = inputLocation;
            _archiveLocation = archiveLocation;
        }

        public string[] GetAllFiles()
        {
            return Directory.GetFiles(_inputLocation);
        }

        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void ArchiveFile(string fileName)
        {
            File.Move(Path.Combine(_inputLocation, fileName), Path.Combine(_archiveLocation, fileName));
        }
        private string _inputLocation;
        private string _archiveLocation;
        
       
    }
}
