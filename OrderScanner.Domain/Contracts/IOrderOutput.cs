using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderScanner.Domain.Models;

namespace OrderScanner.Domain.Contracts
{
    public interface IOrderOutput
    {
        void ProcessOutput();
        void ConfigureOutput(List<OrderOutputItem> orderOutput);
    }
}
