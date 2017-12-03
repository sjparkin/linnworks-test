using Newtonsoft.Json;
using OrderScanner.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Input
{
    public class OrdersInput : IInputItem
    {
        public OrdersInput()
        {
         

        }

        [JsonProperty(PropertyName = "orders")]
        public List<OrderInput> Orders;

    }

    public class OrderInput
    {
        [JsonProperty(PropertyName = "order reference")]
        public string OrderReference { get; set; }

        [JsonProperty(PropertyName = "marketplace")]
        public string Marketplace { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }
    }
}
