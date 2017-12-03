using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Models
{
    public class OrderShipment
    {
        public OrderShipment(string orderReference, string marketplace, string shippingService, string postcode)
        {
            OrderReference = orderReference;
            Marketplace = marketplace;
            ShippingService = shippingService;
            Postcode = postcode;
        }
        public string OrderReference { get; set; }
        public string Marketplace { get; set; }
        public string ShippingService { get; set; }
        public string Postcode { get; set; }
    }
}
