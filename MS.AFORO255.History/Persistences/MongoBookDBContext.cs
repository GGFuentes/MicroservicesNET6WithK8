using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MS.AFORO255.History.Persistences.Settings;

namespace MS.AFORO255.History.Persistences;
public class MongoBookDBContext : IMongoBookDBContext
{
    private IMongoDatabase _db { get; set; }
    private MongoClient _mongoClient { get; set; }
    public IClientSessionHandle? Session { get; set; }
    public MongoBookDBContext(IOptions<Mongosettings> configuration)
    {
        _mongoClient = new MongoClient(configuration.Value.Connection);
        _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
    }
    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _db.GetCollection<T>(name);
    }
}