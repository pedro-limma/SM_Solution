using MongoDB.Driver;
using SMSolution.Adapters.MongoDB.Models;
using System;
using System.Collections.Generic;

namespace SMSolution.Adapters.MongoDB.ConnectionFactory
{
    public class DBConnectionFactory : IDBConnectionFactory, IDisposable
    {
        public Dictionary<string, DBParameterModel> Clusts { get; set; }

        private readonly string _connectionString;
        private readonly string _databaseName;

        public DBConnectionFactory(string connectionString, string databaseName)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;
        }

        public IMongoDatabase Connection(string db)
        {
            return new MongoClient(_connectionString).GetDatabase(_databaseName);
        }

        public MongoClient Client(string db)
        {
            return new MongoClient(_connectionString);
        }

        public void Dispose()
        {
            Clusts.Clear();
            Clusts.TrimExcess();
        }

    }
}
