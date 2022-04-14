using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [BsonCollection("category")]
    public class Category : DatabaseObject
    {
        [BsonElement("Name")]
        public string? Name { get; set; }
        [BsonElement("Description")]
        public string? Description { get; set; }
        public IList<string>? AdditionalFields { get; set; }
    }
}
