using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OilQuality.Data
{
    public class Equipment
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfDefault]
        public string Title { get; set; }

        [BsonIgnoreIfDefault]
        public User User { get; set; }

        [BsonIgnoreIfDefault]
        public DateTime DateBegin { get; set; }

        [BsonIgnoreIfDefault]
        public DateTime DateEnd { get; set; }
    }
}
