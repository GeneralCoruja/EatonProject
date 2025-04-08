using MongoDB.Bson;

namespace EatonAPI.Database.Entities
{
    using MongoDB.Bson.Serialization.Attributes;

    public class Device
    {
        [BsonId] 
        [BsonElement("id")]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("created_date")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("updated_date")]
        public DateTime UpdatedDate { get; set; }
    }
}