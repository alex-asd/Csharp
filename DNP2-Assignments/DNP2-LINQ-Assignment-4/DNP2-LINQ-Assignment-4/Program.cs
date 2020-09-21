using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNP2_LINQ_Ass3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region A

            Customer Kim = new Customer()
            {
                Name = "Kim Foged",
                City = "Beder",
                Orders = new Order[]
                {
                    new Order{
                        Quantity = 1,
                        Product = new Product
                        {
                            Name = "Milk",
                            Price = 9
                        }
                    },
                    new Order{
                        Quantity = 2,
                        Product = new Product
                        {
                            Name = "Butter",
                            Price = 18
                        }
                    },
                    new Order{
                        Quantity = 2,
                        Product = new Product
                        {
                            Name = "Bread",
                            Price = 20
                        }
                    }
                }
            };

            Customer Ib = new Customer()
            {
                Name = "Ib Havn",
                City = "Horsens",
                Orders = new Order[]
                {
                    new Order{
                        Quantity = 3,
                        Product = new Product
                        {
                            Name = "Milk",
                            Price = 9
                        }
                    },
                    new Order{
                        Quantity = 1,
                        Product = new Product
                        {
                            Name = "Butter",
                            Price = 18
                        }
                    },
                    new Order{
                        Quantity = 1,
                        Product = new Product
                        {
                            Name = "Bread",
                            Price = 20
                        }
                    },
                    new Order{
                        Quantity = 1,
                        Product = new Product
                        {
                            Name = "Cacao",
                            Price = 20
                        }
                    }
                }
            };

            Customer Rasmus = new Customer()
            {
                Name = "Rasmus Bjerner",
                City = "Horsens",
                Orders = new Order[]
                {
                    new Order{
                        Quantity = 5,
                        Product = new Product
                        {
                            Name = "Juice",
                            Price = 11
                        }
                    }
                }
            };

            #endregion

            #region B
            List<Customer> Customers = new List<Customer>
            {
                Kim,
                Ib,
                Rasmus
            };
            // Method Syntax
            Console.WriteLine("B:");
            Customers.ToList().ForEach(x => { Console.WriteLine(x.Name + " : " + x.City); });
            Console.WriteLine("\n");
            #endregion

            #region C
            Console.WriteLine("C:");
            Customers.Where(x => x.City == "Horsens").ToList().ForEach(x => { Console.WriteLine(x.Name); });
            Console.WriteLine("\n");
            #endregion

            #region D
            Console.WriteLine("D:");
            // Query Syntax
            var queryD = from c in Customers
                         from o in c.Orders
                         where c.Name == "Ib Havn"
                         select o;

            Console.WriteLine(queryD.Count());
            Console.WriteLine("\n");
            #endregion

            #region E
            Console.WriteLine("E:");
            var queryE = from c in Customers
                         from o in c.Orders
                         where o.Product.Name == "Milk"
                         select c;
            foreach(var c in queryE)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine("\n");
            #endregion

            #region F

            //decimal GetSumForEach(Customer c)
            //{
            //    var sum = c.Orders.Sum(x => x.Quantity * x.Product.Price);
            //    return sum;
            //}

            //var results = from customer in Customers
            //              from order in customer.Orders
            //              let sumForEach = GetSumForEach(customer)
            //              group new { Customer = customer.Name, Spent = order.Product.Price * order.Quantity } by sumForEach into sumGroup
            //              select sumGroup;

            //foreach (var sumGroup in results)
            //{
            //    Console.WriteLine($"Key: {sumGroup.Key}");
            //    foreach(var item in sumGroup)
            //    {
            //        Console.WriteLine($"\t{item.Customer}, {item.Spent}");
            //    }
            //}
            Console.WriteLine("F:");
            (from c in Customers
             let sum = c.Orders.Sum(x => x.Product.Price)
             select new { Name = c.Name, Sum = sum }).ToList().ForEach(x => Console.WriteLine(x.Name + " spent (" + x.Sum + ")"));
            Console.WriteLine("\n");
            #endregion

            #region G
            Console.WriteLine("G:");
            int total = (int)Customers.SelectMany(c => c.Orders).Sum(o => o.Product.Price * o.Quantity);
            Console.WriteLine(total);
            Console.WriteLine("\n");
            #endregion

            while (true) ;
        }
    }
}
