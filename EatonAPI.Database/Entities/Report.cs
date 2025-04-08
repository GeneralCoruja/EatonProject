using MongoDB.Bson.Serialization.Attributes;

namespace EatonAPI.Database.Entities
{
    public class Report
    {
        [BsonId]
        [BsonElement("id")]
        public Guid Id { get; set; }
        
        [BsonElement("message")]
        public string Message { get; set; }
        
        [BsonElement("created_date")]
        public DateTime CreatedDate { get; set; }
    }
}