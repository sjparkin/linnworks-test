using OrderScanner.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Models
{
    public class OrderOutputItem : IOrderOutputItem
    {
        public OrderOutputItem(string orderRef, string marketplace, string name, string surname, 
            string orderItemNumber, string sku, decimal pricePerUnit, int quantity, string postalService, string postcode)
        {
            OrderReference = orderRef;
            Marketplace = marketplace;
            Name = name;
            Surname = surname;
            OrderItemNumber = orderItemNumber;
            Sku = sku;
            PricePerUnit = pricePerUnit.ToString();
            Quantity = quantity.ToString();
            PostalService = postalService;
            Postcode = postcode;
        }
        public string OrderReference { get; set; }
        public string Marketplace { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OrderItemNumber { get; set; }
        public string Sku { get; set; }
        public string PricePerUnit { get; set; }
        public string Quantity { get; set; }
        public string PostalService { get; set; }
        public string Postcode { get; set; }

    }
}
