using MongoDB.Bson;

namespace Models
{
    public class DatabaseObject : IDatabaseObject
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
