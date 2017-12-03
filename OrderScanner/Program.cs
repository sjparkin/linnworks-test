using CSVOutputPlugin;
using FileSystemInputPlugin;
using OrderScanner.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OrderScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLocation = ConfigurationSettings.AppSettings["InputLocation"];
            string archive = ConfigurationSettings.AppSettings["ArchiveLocation"];
            var fileSystem = new FileSystemWrapper(inputLocation, archive);
            var inputter = new FileSystemInput(fileSystem);

            string outputLocation = ConfigurationSettings.AppSettings["OutputLocation"];
            var fileSystemOutput = new OutputFileSystemWrapper(outputLocation);
            var csvBuilder = new CSVBuilder();
            var outputter = new CSVFileOutput(fileSystemOutput, csvBuilder);
            var orderProcessor = new OrderProcessor(outputter);
            inputter.ConfigureProcessor(orderProcessor);
            inputter.Scan();

            var stop = false;
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);
            while(!stop)
            {
                var timer = new System.Threading.Timer((e) =>
                {
                    inputter.Scan();
                }, null, startTimeSpan, periodTimeSpan);
            }
        }
    }
}
