using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Models
{
    public class OrderItem
    {

        public  OrderItem(string orderReference, string marketplace, string orderItemNumber,
            string sku, decimal pricePerUnit, int quantity)
        {
            OrderReference = orderReference;
            Marketplace = marketplace;
            OrderItemNumber = orderItemNumber;
            Sku = sku;
            PricePerUnit = pricePerUnit;
            Quantity = quantity;
        }
        public string OrderReference { get; set; }
        public string Marketplace { get; set; }
        public string OrderItemNumber { get; set; }
        public string Sku { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
    }
}
