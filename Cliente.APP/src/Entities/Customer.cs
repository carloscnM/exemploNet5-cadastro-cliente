using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cliente.APP.Entities
{
    public class Customer 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public string Email { get; set; }

        [BsonRequired]
        public string Phone { get; set; }

        [BsonRequired]
        public string CPF { get; set; }
    }
}
