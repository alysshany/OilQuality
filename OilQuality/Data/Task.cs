using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OilQuality.Data
{
    public class Task
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfDefault]
        public string TaskInfo { get; set; }

        [BsonIgnoreIfDefault]
        public User Worker { get; set; }

        [BsonIgnoreIfDefault]
        public bool isDone = false;
    }
}
