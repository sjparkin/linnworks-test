using Newtonsoft.Json;
using OrderScanner.Domain.Contracts;
using OrderScanner.Domain.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemInputPlugin
{
    public class FileSystemInput : IOrderInput
    {
        public FileSystemInput(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void ConfigureProcessor(IOrderProcessor processor)
        {
            _orderProcessor = processor;
        }

        public void Scan()
        {
            var allFiles = _fileSystem.GetAllFiles();

            foreach(string filePath in allFiles)
            {

                var file = Path.GetFileName(filePath);
                if (file.StartsWith("orders") || file.StartsWith("orderHeaders"))
                {
                    var json = _fileSystem.ReadFile(filePath);
                    var results = JsonConvert.DeserializeObject<OrdersInput>(json);
                    var input = results.Orders;
                    _orderProcessor.HandleInput(input);
                }
                else if (file.StartsWith("OrderItems") || file.StartsWith("items"))
                {
                    var json = _fileSystem.ReadFile(filePath);
                    var results = JsonConvert.DeserializeObject<OrderItemsInput>(json);
                    var input = results.OrderItems;
                    _orderProcessor.HandleInput(input);
                }
                else if (file.StartsWith("shipments"))
                {
                    var json = _fileSystem.ReadFile(filePath);
                    var results = JsonConvert.DeserializeObject<OrderShipmentsInput>(json);
                    var input = results.OrderShipments;
                    _orderProcessor.HandleInput(input);
                }
                //Archive file when done so we don't scan again.
                _fileSystem.ArchiveFile(file);
            }

        }
        private IFileSystem _fileSystem;
        private IOrderProcessor _orderProcessor;
    }
}
