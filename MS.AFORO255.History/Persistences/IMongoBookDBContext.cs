using MongoDB.Driver;

namespace MS.AFORO255.History.Persistences;

public interface IMongoBookDBContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}

