namespace SupermarketTW.Models.SQL
{
    using System.Collections.Generic;

    using SupermarketTW.Models.SQL;

    public class Measure
    {
        private ICollection<Product> products;

        public Measure()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }
    }
}
