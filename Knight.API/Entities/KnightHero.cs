using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Knight.API.Entities
{
    public class KnightHero
    {
        public KnightHero()
        {
            Weapons = Enumerable.Empty<Weapons>();
        }

        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get;  set; }
        public string? NickName { get; set; }
        public DateTime? Birthday { get; set; }
        public IEnumerable<Weapons>? Weapons { get; set; }
        public Attributes? Attributes { get; set; }
        public string KeyAttribute { get; set; }
    }
}
