using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Models
{
    public class OrderDetails
    {
        public OrderDetails(string orderRef, string marketplace, string name, string surname)
        {
            OrderReference = orderRef;
            Marketplace = marketplace;
            Name = name;
            Surname = surname;
        }
        public string OrderReference { get; set; }
        public string Marketplace { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
