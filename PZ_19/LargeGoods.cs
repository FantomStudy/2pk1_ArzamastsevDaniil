using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_19
{
    internal class LargeGoods : Goods
    {
        public LargeGoods(string name, double weight, double dimensions, double deliveryCost) : base(name, weight, dimensions, deliveryCost) { }
        public override double CalculateDeliveryConditions()
        {
            return deliveryCost*1.5;
        }
    }
}
