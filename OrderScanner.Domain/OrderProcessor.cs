using OrderScanner.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderScanner.Domain.Input;
using OrderScanner.Domain.Models;

namespace OrderScanner.Domain
{
    public class OrderProcessor : IOrderProcessor
    {
        public OrderProcessor(IOrderOutput outputter)
        {
            _outputter = outputter;
            _orderDictionary = new Dictionary<OrderKey, Order>();
        }
        public void HandleInput(List<OrderInput> orderInput)
        {
            var orderDetails = orderInput.Select(x => new OrderDetails(x.OrderReference, x.Marketplace,
                x.Name, x.Surname)).ToList();

            foreach(OrderDetails order in orderDetails)
            {
                var orderKey = new OrderKey(order.OrderReference, order.Marketplace);

                var orderOutput = ProcessOrderDetails(orderKey, order);
                if (orderOutput != null)
                {
                    _outputter.ConfigureOutput(orderOutput);
                    _outputter.ProcessOutput();
                }
                
            }
          
        }

        public void HandleInput(List<OrderItemInput> orderItemInput)
        {
            var groupedItems = orderItemInput.GroupBy(x => new { x.OrderReference, x.Marketplace });
            
            foreach(var items in groupedItems)
            {
                var orderItems = items.Select(x =>
                                            new OrderItem(x.OrderReference, x.Marketplace, x.OrderItemNumber, x.Sku,
                                            x.PricePerUnit, x.Quantity))
                                            .ToList();


                var orderKey = new OrderKey(items.Key.OrderReference, items.Key.Marketplace);

                var orderOutput = ProcessOrderItems(orderKey, orderItems);
                if (orderOutput != null)
                {
                    _outputter.ConfigureOutput(orderOutput);
                    _outputter.ProcessOutput();
                }
            }
            
        }

        public void HandleInput(List<OrderShipmentInput> orderShipmentInput)
        {
            var orderShipments = orderShipmentInput.Select(x => 
                                        new OrderShipment(x.OrderReference, x.Marketplace, x.ShippingService, x.Postcode));
            foreach (OrderShipment orderShipment in orderShipments)
            {
                var orderKey = new OrderKey(orderShipment.OrderReference, orderShipment.Marketplace);

                var orderOutput = ProcessOrderShipment(orderKey, orderShipment);
                if (orderOutput != null)
                {
                    _outputter.ConfigureOutput(orderOutput);
                    _outputter.ProcessOutput();
                }
            }
        }

        public List<OrderOutputItem> ProcessOrderDetails(OrderKey orderKey, OrderDetails orderDetails)
        {
            if (!_orderDictionary.ContainsKey(orderKey))
            {
                //create new order and assume no output
                var order = new Order()
                {
                    OrderDetails = orderDetails
                };
                _orderDictionary.Add(orderKey, order);
                return null;
            }
            else
            {
                var order = _orderDictionary[orderKey];
                if (order.OrderDetails != null) return null;
                
                order.OrderDetails = orderDetails;
                if (!order.OrderComplete()) return null;

                return order.MapToOutputItems();
            }
        }

        public List<OrderOutputItem> ProcessOrderItems(OrderKey orderKey, List<OrderItem> orderItems)
        {
            if (!_orderDictionary.ContainsKey(orderKey))
            {
                //create new order and assume no output
                var order = new Order()
                {
                    OrderItems = orderItems
                };
                _orderDictionary.Add(orderKey, order);
                return null;
            }
            else
            {
                var order = _orderDictionary[orderKey];
                order.OrderItems = orderItems;
                if (!order.OrderComplete()) return null;
                return order.MapToOutputItems();

            }
        }

        public List<OrderOutputItem> ProcessOrderShipment(OrderKey orderKey, OrderShipment orderShipment)
        {
            if (!_orderDictionary.ContainsKey(orderKey))
            {
                //create new order and assume no output
                var order = new Order()
                {
                    OrderShipment = orderShipment
                };
                _orderDictionary.Add(orderKey, order);
                return null;
            }
            else
            {
                var order = _orderDictionary[orderKey];
                if (order.OrderShipment != null) return null;

                order.OrderShipment = orderShipment;
                if (!order.OrderComplete()) return null;

                return order.MapToOutputItems();
            }
        }

        private Dictionary<OrderKey, Order> _orderDictionary;
        private IOrderOutput _outputter;
    }
}
