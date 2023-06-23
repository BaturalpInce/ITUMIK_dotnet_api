using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ITUMIK_dotnet_api.Models;


public class Entry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string? Id { get; set; }
    public string TOPIC { get; set; } = null!;
    public Dictionary<string, bool> VALUES { get; set; } = null!;

}