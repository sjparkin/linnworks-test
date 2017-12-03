using OrderScanner.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderScanner.Domain.Models;

namespace CSVOutputPlugin
{
    public class CSVFileOutput : IOrderOutput
    {
        public CSVFileOutput(IOutputFileSystem csvOutput, ICSVBuilder csvBuilder)
        {
            _csvOutput = csvOutput;
            _csvBuilder = csvBuilder;
        }

        public void ProcessOutput()
        {
            var orderRef = _orderOutputItems.First().OrderReference;
            var market = _orderOutputItems.First().Marketplace;

            var uniqueFileName = String.Format("Order_{0}_{1}.csv", orderRef, market);
            var lines = _orderOutputItems.Select(x => _csvBuilder.BuildCSV(x));
            _csvOutput.WriteFile(lines.ToArray(), uniqueFileName);
        }

        public void ConfigureOutput(List<OrderOutputItem> orderOutput)
        {
            _orderOutputItems = orderOutput;
        }

        private IOutputFileSystem _csvOutput;
        private ICSVBuilder _csvBuilder;
        private List<OrderOutputItem> _orderOutputItems;
    }
}
