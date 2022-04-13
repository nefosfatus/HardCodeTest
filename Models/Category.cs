using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [BsonCollection("category")]
    public class Category : DatabaseObject
    {
        [BsonElement("Name")]
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public List<string>? AdditionalFields { get; set; }
    }
}
