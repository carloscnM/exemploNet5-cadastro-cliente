using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerApp.Entities
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

        private string cpf;
        
        [BsonRequired]
        public string CPF { get => cpf; set => cpf = Utils.CPF.OnlyNumber(value); }
    }
}
