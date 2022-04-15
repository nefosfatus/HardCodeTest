namespace Models
{
    [BsonCollection("category")]
    public class Category : DatabaseObject
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IList<string>? AdditionalFields { get; set; }
    }
}
