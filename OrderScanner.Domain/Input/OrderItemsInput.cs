using Newtonsoft.Json;
using OrderScanner.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Input
{
    public class OrderItemsInput : IInputItem
    {
        public OrderItemsInput()
        {
        }
        [JsonProperty(PropertyName = "order items")]
        public List<OrderItemInput> OrderItems;

    }

    public class OrderItemInput
    {
        [JsonProperty(PropertyName = "order reference")]
        public string OrderReference { get; set; }

        [JsonProperty(PropertyName = "marketplace")]
        public string Marketplace { get; set; }

        [JsonProperty(PropertyName = "order item number")]
        public string OrderItemNumber { get; set; }

        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }
        [JsonProperty(PropertyName = "price per unit")]
        public decimal PricePerUnit { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}
