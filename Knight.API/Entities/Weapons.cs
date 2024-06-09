using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Knight.API.Entities
{
    public class Weapons
    {
        public string? Name { get; set; }
        public int? Mod { get; set; }
        public string? Attr { get; set; }
        public bool? Equipped { get; set; }
    }
}
