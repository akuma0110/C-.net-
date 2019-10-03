using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WingtipToys.Model2
{
    public class ProductDatabaseInitializer : DropCreateDatabaseAlways<ProductContext>
    {

        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }        
        private static List<Category> GetCategories()
        {
            var category = new List<Category>
            {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Cars"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Motobike"
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
                    Description =  "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." +
 "Power it up and let it go!",
                    ImagePath="carconvert.png",
                    UnitPrice = 22.50,
                    CategoryID = 1                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Old-Time Car",
                    Description =  "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." +
 "Power it up and let it go!",
                    ImagePath="carearly.png",
                    UnitPrice = 15.95,
                    CategoryID = 2
                }
            };
            return product;
        }
    }
}