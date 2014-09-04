namespace SupermarketTW.Models.MongoDb
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class ProductDocument
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        
        public double BasePrice { get; set; }

        public string Vendor { get; set; }

        public string Measure { get; set; }
    }
}
