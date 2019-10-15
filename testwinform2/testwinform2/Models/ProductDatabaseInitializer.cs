using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace testwinform2.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }        
        private static  List<Category> GetCategories()
        {
            var category = new List<Category>
            {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "car",
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "old-time car",
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "motobike",
                }
            };
            return category;
        }

        private static List<Product> GetProducts()
        {
            var product = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Convertible Car",
                    Description = "aaa",
                    UnitPrice = 22.5,
                    CategoryID = 1,
                },
                 new Product
                {
                    ProductID = 2,
                    ProductName = "dddd Car",
                    Description = "ddd",
                    UnitPrice = 19.25,
                    CategoryID = 2,
                },
                  new Product
                {
                    ProductID = 3,
                    ProductName = " ccccc Car",
                    Description = "ccccccc",
                    UnitPrice = 109.35,
                    CategoryID = 3,
                }
            };
            return product;
        }
    }
}