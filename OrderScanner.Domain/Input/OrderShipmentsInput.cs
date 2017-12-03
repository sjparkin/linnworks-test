using Newtonsoft.Json;
using OrderScanner.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Input
{
    public class OrderShipmentsInput : IInputItem
    {
        public OrderShipmentsInput()
        {

        }
        [JsonProperty(PropertyName = "orders")]
        public List<OrderShipmentInput> OrderShipments;
       
    }

    public class OrderShipmentInput
    {
        [JsonProperty(PropertyName = "order reference")]
        public string OrderReference { get; set; }

        [JsonProperty(PropertyName = "marketplace")]
        public string Marketplace { get; set; }

        [JsonProperty(PropertyName = "postal service")]
        public string ShippingService { get; set; }

        [JsonProperty(PropertyName = "postcode")]
        public string Postcode { get; set; }
    }
}
