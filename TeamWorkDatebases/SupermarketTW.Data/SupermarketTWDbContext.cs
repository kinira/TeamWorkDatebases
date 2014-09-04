namespace SupermarketTW.Data
{
    using System.Data.Entity;
    using SupermarketTW.Models.SQL;

    public class SupermarketTWDbContext : DbContext
    {
        public IDbSet<Product> Products { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Measure> Measures { get; set; }
    }
}
