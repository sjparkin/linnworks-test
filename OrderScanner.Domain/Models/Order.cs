using OrderScanner.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Models
{
    public class Order
    {
        public Order()
        {

        }
        public OrderDetails OrderDetails { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public OrderShipment OrderShipment { get; set; }

        public bool OrderComplete()
        {
            return OrderDetails != null && OrderShipment != null && OrderItems != null && OrderItems.Count > 0;
        }

        public List<OrderOutputItem> MapToOutputItems()
        {
            //Assume we have all as Order Complete has been run.
            if (!OrderComplete()) return null;

            var outputItems = OrderItems.Select(x =>
                                new OrderOutputItem(OrderDetails.OrderReference, OrderDetails.Marketplace, OrderDetails.Name, OrderDetails.Surname,
                                x.OrderItemNumber, x.Sku, x.PricePerUnit, x.Quantity, OrderShipment.ShippingService, OrderShipment.Postcode));
            return outputItems.ToList();
        }
    }
}
