using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderScanner.Domain.Models;

namespace CSVOutputPlugin
{
    public class CSVBuilder : ICSVBuilder
    {
        public CSVBuilder() { }
        public string BuildCSV(OrderOutputItem item)
        {
            return String.Join( ",",
                ToCsvString(item.OrderReference),
                ToCsvString(item.Marketplace),
                ToCsvString(item.Name),
                ToCsvString(item.Surname),
                ToCsvString(item.OrderItemNumber),
                ToCsvString(item.Sku),
                ToCsvString(item.PricePerUnit),
                ToCsvString(item.Quantity),
                ToCsvString(item.PostalService),
                ToCsvString(item.Postcode));
        }

        public static string ToCsvString(string str)
        {
            string result = str;
            if (result.Contains("\""))
            {
                result = result.Replace("\"", "\"\"");
            }
            if (result.Contains(",") || result.Contains(Environment.NewLine))
            {
                result = string.Format("\"{0}\"", result);
            }
            return result;
        }
    }
}
