namespace SupermarketTW
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using SupermarketTW.Data;
    using SupermarketTW.Data.Migrations;
    using SupermarketTW.Models.MongoDb;
    using SupermarketTW.Models.SQL;
    using MongoDB.Driver;

    class Program
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "Supermarket";

        static void Main()
        {
            RecodeFromMongoDbToSQL(GetMongoDatabase(DatabaseName, DatabaseHost), new SupermarketTWDbContext());
        }

        static MongoDatabase GetMongoDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        static void RecodeFromMongoDbToSQL(MongoDatabase mongoDb, DbContext sqlDbContext)
        {
            //SQL DB server
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SupermarketTWDbContext, Configuration>());
            var sqlDb = sqlDbContext as SupermarketTWDbContext;

            //Mongo DB server
            var products = mongoDb.GetCollection<ProductDocument>("Products").FindAll();
            
            foreach (var product in products)
            {
                if (sqlDb.Products.FirstOrDefault(p => p.Name.Equals(product.Name)) == null)
                {
                    var measure = sqlDb.Measures.FirstOrDefault(m => m.Name.Equals(product.Measure));
                    if (measure == null)
                    {
                        measure = new Measure()
                        {
                            Name = product.Measure
                        };
                        sqlDb.Measures.Add(measure);
                    }

                    var vendor = sqlDb.Vendors.FirstOrDefault(v => v.Name.Equals(product.Vendor));
                    if (vendor == null)
                    {
                        vendor = new Vendor()
                        {
                            Name = product.Vendor
                        };
                        sqlDb.Vendors.Add(vendor);
                    }

                    var newProduct = new Product()
                    {
                        Name = product.Name,
                        BasePrice = product.BasePrice,
                        Vendor = vendor,
                        Measure = measure
                    };

                    sqlDb.Products.Add(newProduct);
                    sqlDbContext.SaveChanges();
                }
            }            
        }
    }
}
