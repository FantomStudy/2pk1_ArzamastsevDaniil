using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_19
{
    internal class SmallGoods : Goods
    {
        public SmallGoods(string name, double weight, double dimensions, double deliveryCost) : base(name, weight, dimensions, deliveryCost) { }
        public override double CalculateDeliveryConditions()
        {
            return deliveryCost*0.8;
        }
    }
}
