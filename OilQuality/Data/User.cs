using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OilQuality.Data
{
    public class User
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfDefault]
        public string Surname { get; set; }

        [BsonIgnoreIfDefault]
        public string Name { get; set; }

        [BsonIgnoreIfDefault]
        public string? Patronymic { get; set; }

        [BsonIgnoreIfDefault]
        public string Login { get; set; }

        [BsonIgnoreIfDefault]
        public string Password { get; set; }

        [BsonIgnoreIfDefault]
        public string RoleName { get; set; }
    }
}
