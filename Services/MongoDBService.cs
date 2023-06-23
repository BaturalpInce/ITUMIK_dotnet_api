using ITUMIK_dotnet_api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace ITUMIK_dotnet_api.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Entry> _entryCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _entryCollection = database.GetCollection<Entry>(mongoDBSettings.Value.CollectionName);
    }

    // this function can help frontend developers to see each topic name simply, so
    // that they can GET request by just adding those topics to url
    public async Task<List<string>> GetTopicsAsync()
    {
        var filter = Builders<Entry>.Filter.Empty;
        var topics = await _entryCollection
            .Find(filter)
            .Project(doc => doc.TOPIC )
            .ToListAsync();

        return topics;
    }

    // return all documents
    public async Task<List<Entry>> GetAsync()
    {
        return await _entryCollection.Find(new BsonDocument()).ToListAsync();
    }

    // return list of all desks spesified by a floor
    public async Task<List<EntryWithoutID>> GetDesksByFloor(string floor)
    {
        var filter = Builders<Entry>.Filter.Regex(e => e.TOPIC, new BsonRegularExpression("^" + floor + "/"));

        var desks = await _entryCollection
            .Find(filter)
            .Project(doc => new EntryWithoutID{ TOPIC = doc.TOPIC, VALUES = doc.VALUES })
            .ToListAsync();

        return desks;
    }

    // return list of all chairs spesified by a desk and floor value
    public async Task<List<EntryWithoutID>> GetChairsByDesk(string floor, string desk)
    {
        var filter = Builders<Entry>.Filter.Eq(e => e.TOPIC, floor + "/" + desk);

        var documents = await _entryCollection
            .Find(filter)
            .Project(doc => new EntryWithoutID { TOPIC = doc.TOPIC, VALUES = doc.VALUES })
            .ToListAsync();

        return documents;
    }

}