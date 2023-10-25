using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OilQuality.Data
{
    public class Analyze
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfDefault]
        public string Title { get; set; }

        [BsonIgnoreIfDefault]
        public string Type { get; set; }

        [BsonIgnoreIfDefault]
        public string Deposit { get; set; }

        [BsonIgnoreIfDefault]
        public string DefinedIndicatorData { get; set; }

        [BsonIgnoreIfDefault]
        public string MethodData { get; set; }

        [BsonIgnoreIfDefault]
        public DateTime? DateOfFinishing { get; set; }

        [BsonIgnoreIfDefault]
        public User? WorkerData { get; set; }

        [BsonIgnoreIfDefault]
        public string? ResultData { get; set; }

        [BsonIgnoreIfDefault]
        public bool isFinished = false;
    }
}
