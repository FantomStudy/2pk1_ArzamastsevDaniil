namespace PZ_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Goods product1 = new SmallGoods("processor 1", 0.2, 0.00029, 10);
            Goods product2 = new SmallGoods("processor 2", 0.3, 0.00031, 10);
            Goods product3 = new SmallGoods("processor 3", 0.1, 0.0003, 10);
            Goods product4 = new LargeGoods("videocard 1", 1.0, 0.00878, 10);
            Goods product5 = new LargeGoods("videocard 2", 1.2, 0.00873, 10);
            Goods product6 = new LargeGoods("videocard 3", 0.8, 0.00875, 10);
            Goods product7 = new MediumGoods("cooler 1", 0.7, 0.0042, 10);
            Goods product8 = new MediumGoods("cooler 2", 0.4, 0.0039, 10);
            Goods product9 = new MediumGoods("cooler 3", 0.6, 0.004, 10);
            Goods product10 = new MediumGoods("psu 1", 0.5, 0.003, 10);

            Console.WriteLine(product1.ToString());
            Console.WriteLine(product2.ToString());
            Console.WriteLine(product3.ToString());
            Console.WriteLine(product4.ToString());
            Console.WriteLine(product5.ToString());
            Console.WriteLine(product6.ToString());
            Console.WriteLine(product7.ToString());
            Console.WriteLine(product8.ToString());
            Console.WriteLine(product9.ToString());
            Console.WriteLine(product10.ToString());

            double totalWeight = product1 + product4;
            Console.WriteLine($"Total weight of product1 and product4: {totalWeight} \n" +
                $"--------------------------------------------------------------");
            totalWeight = product10 + product5;
            Console.WriteLine($"Total weight of product10 and product5: {totalWeight} \n" +
                $"--------------------------------------------------------------");
            Console.WriteLine($"Is delivery cost of product1({product1.CalculateDeliveryConditions()}) greater than cost of product6({product6.CalculateDeliveryConditions()})? \n{product1 > product6} \n" +
                $"--------------------------------------------------------------");
            Console.WriteLine($"Is delivery cost of product2({product2.CalculateDeliveryConditions()}) less than cost of product7 ({product7.CalculateDeliveryConditions()})? \n{product2 < product7} \n" +
                $"--------------------------------------------------------------");
            Console.WriteLine($"Is delivery cost of product3({product3.CalculateDeliveryConditions()})greater than or equal to cost of product8({product8.CalculateDeliveryConditions()})? \n{product1 >= product8} \n" +
                $"--------------------------------------------------------------");
            Console.WriteLine($"Is delivery cost of product4({product4.CalculateDeliveryConditions()})less than or equal to cost of product9({product9.CalculateDeliveryConditions()})? \n{product4 <= product9} \n" +
                $"--------------------------------------------------------------");
            Console.WriteLine($"Is delivery cost of product5({product5.CalculateDeliveryConditions()}) equal to cost of product9({product9.CalculateDeliveryConditions()})? \n{product5 == product9} \n" +
                $"--------------------------------------------------------------");
            Console.WriteLine($"Is delivery cost of product6({product6.CalculateDeliveryConditions()}) not equal to cost of product10({product10.CalculateDeliveryConditions()})? \n{product6 != product10} \n" +
                $"--------------------------------------------------------------");
        }
    }
}