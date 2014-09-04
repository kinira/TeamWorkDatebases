namespace SupermarketTW.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SupermarketTWDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "SupermarketTW.Data.SupermarketTWDbContext";
        }

        protected override void Seed(SupermarketTWDbContext context)
        {
            
        }
    }
}
