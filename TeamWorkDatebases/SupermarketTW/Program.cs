namespace SupermarketTW
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using SupermarketTW.Data;
    using SupermarketTW.Models.SQL;
    using SupermarketTW.Data.Migrations;

    class Program
    {
        static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SupermarketTWDbContext, Configuration>());
            var db = new SupermarketTWDbContext();

            var measure = db.Measures.First(m => m.Name.Equals("liters"));

            var vendor = db.Vendors.First(v => v.Name.Equals("THE COCA COLA COMPANY"));

            var product1 = new Product()
            {
                Name = "Coca cola Light",
                BasePrice = 1.92,
                Measure = measure,
                Vendor = vendor
            };

            db.Products.Add(product1);
            db.SaveChanges();

            var products = db.Products.ToList();

            foreach (var product in products)
            {
                System.Text.StringBuilder output = new System.Text.StringBuilder();
                output.AppendLine("id: " + product.Id);
                output.AppendLine("name: " + product.Name);
                output.AppendLine("price: " + product.BasePrice);
                output.AppendLine("vendor: " + product.Vendor);
                output.AppendLine("measure: " + product.Measure);
                output.AppendLine(new string('-', 50));

                Console.WriteLine(output.ToString());
            }
        }
    }
}
