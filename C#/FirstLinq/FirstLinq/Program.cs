using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FirstLinq
{

    //intercal manual
    //Linq standard query operators.
    class Program
    {
        //Lambda as a static method?!?
        static public Action<int> printNumber = x => Console.WriteLine(x);

        static void Main(string[] args)
        {
            ProductClass[] prods = CreateProducts();

            //----------------------------------------------------
            ProductClass beer = Array.Find(prods, FindBeer);
            Console.WriteLine(beer.TextIt());

            ProductClass beer1 = Array.Find(prods,
                delegate(ProductClass p)
                {
                    return p.Name == "Beer";
                });
            Console.WriteLine(beer1.TextIt());

            ProductClass beer2 = Array.Find(prods,
                p =>
                {
                    return p.Name == "Beer";
                });
            Console.WriteLine(beer2.TextIt());

            ProductClass beer3 = Array.Find(prods, p => p.Name == "Beer" );
            Console.WriteLine(beer3.TextIt());
            //-----------------------------------------------------

            var prodsFiltered = prods.Where (p => 
                {
                    string temp = p.Name.ToLower();
                    return temp.StartsWith("z");
                });

            foreach (ProductClass p in prodsFiltered)
            {
                Console.WriteLine(p.TextIt());
            }

            //-------------------------------------------------

            Action<int> printNumber = x => Console.WriteLine(x);

            printNumber(23);

            Program.printNumber(22);
        }

        private static ProductClass[] CreateProducts()
        {
            ProductClass[] prods = new ProductClass[]
            {
                new ProductClass {Name ="Displayport Adapter", Quantity = 1, UnitPrice=25.50m},
                new ProductClass {Name ="Beer", Quantity = 12, UnitPrice=10.99m},
                new ProductClass {Name ="Z-Wave USB Controller", Quantity = 1, UnitPrice=49.99m},
                new ProductClass {Name ="ZigBee Plugwise Starter Kit", Quantity = 1, UnitPrice=209.00m},
            };
            return prods;
        }

        static bool FindBeer(ProductClass p)
        {
            return p.Name == "Beer";
        }

        private static void LinqOnDB()
        {
            //do the stuff on page 88 first
            ProductsDataContext pdc = new ProductsDataContext();

            var products = from p in pdc.Products
                           where p.Category.CategoryName == "Beverages"
                           orderby p.ProductName descending
                           select p;

            foreach (Product prod in products)
            {
                Console.WriteLine(prod.ProductName);
            }

            var categories = from c in pdc.Categories
                             orderby c.Products.Average(u => u.UnitPrice)
                             select c;
            foreach (Category cat in categories)
            {
                Console.WriteLine(cat.Description);
            }
        }

        private static void createXDocument()
        {
            IEnumerable<ProductClass> prods = new List<ProductClass>()
            {
                new ProductClass {Name ="Displayport Adapter", Quantity = 1, UnitPrice=25.50m},
                new ProductClass {Name ="Beer", Quantity = 12, UnitPrice=10.99m},
                new ProductClass {Name ="Z-Wave USB Controller", Quantity = 1, UnitPrice=49.99m},
                new ProductClass {Name ="ZigBee Plugwise Starter Kit", Quantity = 1, UnitPrice=209.00m},
            };

            XDocument xmlDoc = new XDocument(
                new XElement("products", from p in prods
                                         select new XElement("product",
                                             new XAttribute("quantity", p.Quantity),
                                             new XAttribute("unitprice", p.UnitPrice),
                                             new XText(p.Name))));

            Console.WriteLine(xmlDoc.ToString());
            Console.WriteLine("------------------------------------------------");

            var names = from p in xmlDoc.Descendants("product")
                        where (decimal) p.Attribute("unitprice") > 20m
                            orderby p.Value ascending
                            select p.Value;
            foreach (string n in names)
            {
                Console.WriteLine(n);
            }

        }

        private static void DelayedExexcution()
        {
            IEnumerable<ProductClass> prods = new List<ProductClass>()
            {
                new ProductClass {Name ="Displayport Adapter", Quantity = 1, UnitPrice=25.50m},
                new ProductClass {Name ="Beer", Quantity = 12, UnitPrice=10.99m},
                new ProductClass {Name ="Z-Wave USB Controller", Quantity = 1, UnitPrice=49.99m},
                new ProductClass {Name ="ZigBee Plugwise Starter Kit", Quantity = 1, UnitPrice=209.00m},
            };

            var q = from p in prods
                    where p.UnitPrice > 30.00m
                    orderby p.Name
                    select p;
            ((List<ProductClass>)prods).Add(new ProductClass { Name = "Coffee", Quantity = 50, UnitPrice = 32.25m });

            foreach (ProductClass pr in q)
            {
                Console.WriteLine(pr.Name);
            }
        }

        private static void LinqedList()
        {
            IEnumerable<ProductClass> prods = new List<ProductClass>()
            {
                new ProductClass {Name ="Displayport Adapter", Quantity = 1, UnitPrice=25.50m},
                new ProductClass {Name ="Beer", Quantity = 12, UnitPrice=10.99m},
                new ProductClass {Name ="Z-Wave USB Controller", Quantity = 1, UnitPrice=49.99m},
                new ProductClass {Name ="ZigBee Plugwise Starter Kit", Quantity = 1, UnitPrice=209.00m},
            };

            var q = from p in prods
                    where p.UnitPrice > 30.00m
                    orderby p.Name
                    select p;

            foreach (ProductClass pr in q)
            {
                Console.WriteLine(pr.Name);
            }
        }

        private static void FirstLinq()
        {
            string[] products = {"Fish and Chips", 
                                  "Quarter pounder with Cheese", 
                                  "Veggie Burgers", 
                                  "Donner Kebab"};

            var q = from p in products
                    orderby p
                    select p;

            foreach (string prod in q)
            {
                Console.WriteLine(prod);
            }
        }
    }
}
