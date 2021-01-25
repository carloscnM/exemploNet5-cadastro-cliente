using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cliente.APP.Entities
{
    public class RestrictiveList 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CPF { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finish { get; set; }
    }
}
