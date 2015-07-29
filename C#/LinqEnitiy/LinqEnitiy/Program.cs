using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEnitiy
{
    class Program
    {
        static public Action<string> print = x => Console.WriteLine(x);

        static void Main(string[] args)
        {
            
        }

        private static void Delete()
        {
            var theEntityData = new NorthwindEntities();

            var onecat = (from c in theEntityData.Categories
                          where c.Name == "A New One MOD"
                          select c).First();

            theEntityData.DeleteObject(onecat);
            theEntityData.SaveChanges();
        }

        private static void Update()
        {
            var theEntityData = new NorthwindEntities();

            var onecat = (from c in theEntityData.Categories
                          where c.Name == "A New One"
                          select c).First();
            onecat.Name = "A New One MOD";
            theEntityData.SaveChanges();
        }

        private static void AddData()
        {
            var theEntityData = new NorthwindEntities();

            //add
            Category NewC = new Category()
            {
                Name = "A new One",
                Description = "A test of the entity framework"
            };

            theEntityData.AddToCategories(NewC);
            theEntityData.SaveChanges();
        }

        private static void GetData()
        {
            var theEntityData = new NorthwindEntities();

            var products = from p in theEntityData.Products
                           where p.Category.Name == "Beverages"
                           select p;
            foreach (var pb in products.Take(5))
            {
                Console.WriteLine(pb.Name);
            }

            var products2 = theEntityData.ProductsInCategory("Beverages");

            foreach (var pb in products2.Take(5))
            {
                Console.WriteLine(pb.Name);
            }

        }
    }
}
