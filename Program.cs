using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<String, int> d1 = new Dictionary<String, int>();
            d1.Add("A", 3);
            Dictionary<String, int> d2 = new Dictionary<String, int>();
            d2.Add("B", 2);
            Dictionary<String, int> d3 = new Dictionary<String, int>();
            d3.Add("C", 1);
            d3.Add("D", 1);
            List<Promotion> promotions = new List<Promotion>()
    {
        new Promotion(1, d1, 130),
        new Promotion(2, d2, 45),
        new Promotion(3, d3, 30)
    };
            Quantities quantities = new Quantities();
            Console.WriteLine("Quantity of SKU A!");
            quantities.SKUA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quantity of SKU B!");
            quantities.SKUB = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quantity of SKU C!");
            quantities.SKUC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quantity of SKU D!");
            quantities.SKUD = Convert.ToInt32(Console.ReadLine());

            List<Order> orders = new List<Order>();
            List<Product> products = new List<Product>();
            if (quantities.SKUA >0)
            {
                for (int i = 0; i < quantities.SKUA; i++)
                {
                    Product product = new Product("A");
                    products.Add(product);
                }
            }
            if (quantities.SKUB > 0)
            {
                for (int i = 0; i < quantities.SKUB; i++)
                {
                    Product product = new Product("B");
                    products.Add(product);
                }
            }
            if (quantities.SKUC > 0)
            {
                for (int i = 0; i < quantities.SKUC; i++)
                {
                    Product product = new Product("C");
                    products.Add(product);
                }
            }
            if (quantities.SKUD > 0)
            {
                for (int i = 0; i < quantities.SKUD; i++)
                {
                    Product product = new Product("D");
                    products.Add(product);
                }
            }
            Order order1 = new Order(1, products);
            //Order order1 = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("C"), new Product("D") });
            //Order order2 = new Order(2, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("B") });
            //Order order3 = new Order(3, new List<Product>() { new Product("A"), new Product("A"), new Product("D"), new Product("B"), new Product("B") });
            orders.AddRange(new Order[] { order1 });
            //check if order meets promotion
            foreach (Order ord in orders)
            {
                List<decimal> promoprices = promotions
                    .Select(promo => PromotionChecker.GetTotalPrice(ord, promo))
                    .ToList();
                decimal origprice = ord.Products.Sum(x => x.Price);
                decimal promoprice = promoprices.Sum();
                Console.WriteLine($"OrderID: {ord.OrderID} => Original price: {origprice.ToString("0.00")} | Final price: {promoprice.ToString("0.00")} | Discount: {(origprice - promoprice).ToString("0.00")}");
            }
          
        }
    }
}
