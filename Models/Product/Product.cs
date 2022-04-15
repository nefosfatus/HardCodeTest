namespace Models
{
    [BsonCollection("product")]
    public class Product : DatabaseObject
    {
        public Product()
        {
            if (AdditionalFields is null)
            {
                AdditionalFields = new List<AdditionalField>();
            }
        }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public IList<AdditionalField> AdditionalFields { get; set; }
    }
}
