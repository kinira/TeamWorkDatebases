namespace SupermarketTW.Models.SQL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using SupermarketTW.Models.SQL;

    public class Product
    {
        private Measure measure;

        private Vendor vendor;
        
        public Product()
        {
            this.measure = new Measure();
            this.vendor = new Vendor();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double BasePrice { get; set; }

        public virtual Measure Measure
        {
            get
            {
                return this.measure;
            }

            set
            {
                this.measure = value;
            }
        }

        public virtual Vendor Vendor
        {
            get
            {
                return this.vendor;
            }

            set
            {
                this.vendor = value;
            }
        }
    }
}
