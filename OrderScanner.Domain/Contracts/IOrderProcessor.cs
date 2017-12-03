using OrderScanner.Domain.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Contracts
{
    public interface IOrderProcessor
    {
        void HandleInput(List<OrderInput> orderInput);
        void HandleInput(List<OrderItemInput> orderItemInput);
        void HandleInput(List<OrderShipmentInput> orderShipmentInput);
    }
}
