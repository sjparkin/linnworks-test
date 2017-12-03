using OrderScanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVOutputPlugin
{
    public interface ICSVBuilder
    {
        string BuildCSV(OrderOutputItem item);

    }
}
