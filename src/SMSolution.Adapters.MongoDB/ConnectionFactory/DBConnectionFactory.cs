using MongoDB.Driver;
using SMSolution.Adapters.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMSolution.Adapters.MongoDB.ConnectionFactory
{
    public class DBConnectionFactory : IDbConnectionFactory, IDisposable
    {
        public Dictionary<string, DBParameterModel> Clusts { get; set; }
        public IMongoDatabase Connection(string db)
        {
            DBParameterModel database = Clusts.Where(x => x.Key.CompareTo(db) == 0).FirstOrDefault().Value;

            return new MongoClient(database.GetConnectionString()).GetDatabase(database.Database);
        }

        public MongoClient Client(string db)
        {
            DBParameterModel database = Clusts.Where(x => x.Key.CompareTo(db) == 0).FirstOrDefault().Value;

            return new MongoClient(database.GetConnectionString());
        }

        public void Dispose()
        {
            Clusts.Clear();
            Clusts.TrimExcess();
        }

    }
}
