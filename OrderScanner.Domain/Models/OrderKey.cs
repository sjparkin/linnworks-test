using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Models
{
    public class OrderKey
    {
        public OrderKey(string orderReference, string marketplace)
        {
            OrderReference = orderReference;
            Marketplace = marketplace;
        }
        public string OrderReference { get; set; }
        public string Marketplace { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is OrderKey x)) return false;
            return x.OrderReference == OrderReference && x.Marketplace == Marketplace;
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(OrderReference.GetHashCode(), Marketplace.GetHashCode());
        }

        public int CombineHashCodes(int h1, int h2)
        {
            return (((h1 << 5) + h1) ^ h2);
        }
    }
}
