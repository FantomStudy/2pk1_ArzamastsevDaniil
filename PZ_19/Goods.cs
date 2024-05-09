using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_19
{
    internal class Goods
    {
        public string name { get; set; }
        public double weight { get; set; }
        public double dimensions { get; set; }
        public double deliveryCost { get; set; }
        public Goods(string name, double weight, double dimensions, double deliveryCost)
        {
            this.name = name;
            this.weight = weight;
            this.dimensions = dimensions;
            this.deliveryCost = deliveryCost;
        }
        public virtual double CalculateDeliveryConditions()
        {
            return deliveryCost;
        }
        public static bool operator ==(Goods item1, Goods item2)
        {
            return item1.CalculateDeliveryConditions() == item2.CalculateDeliveryConditions();
        }

        public static bool operator !=(Goods item1, Goods item2)
        {
            return item1.CalculateDeliveryConditions() != item2.CalculateDeliveryConditions();
        }

        public static bool operator >(Goods item1, Goods item2)
        {
            return item1.CalculateDeliveryConditions() > item2.CalculateDeliveryConditions();
        }

        public static bool operator <(Goods item1, Goods item2)
        {
            return item1.CalculateDeliveryConditions() < item2.CalculateDeliveryConditions();
        }

        public static bool operator >=(Goods item1, Goods item2)
        {
            return item1.CalculateDeliveryConditions() >= item2.CalculateDeliveryConditions();
        }

        public static bool operator <=(Goods item1, Goods item2)
        {
            return item1.CalculateDeliveryConditions() <= item2.CalculateDeliveryConditions();
        }

        public static double operator +(Goods item1, Goods item2)
        {
            return item1.weight + item2.weight;
        }

        public static double operator -(Goods item1, Goods item2)
        {
            return item1.weight - item2.weight;
        }
        public override string ToString()
        {
            return $" Name: {name}, \n Weight: {weight} kg, \n Dimensions: {dimensions} cubic meters, \n Delivery Cost: ${CalculateDeliveryConditions()} \n" +
                $"--------------------------------------------------------------";
        }
    }
}
