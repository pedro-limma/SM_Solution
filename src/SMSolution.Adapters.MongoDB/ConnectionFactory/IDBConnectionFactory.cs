using MongoDB.Driver;

namespace SMSolution.Adapters.MongoDB.ConnectionFactory
{
    public interface IDBConnectionFactory
    {
        public IMongoDatabase Connection(string db);
        public MongoClient Client(string db);
    }
}
