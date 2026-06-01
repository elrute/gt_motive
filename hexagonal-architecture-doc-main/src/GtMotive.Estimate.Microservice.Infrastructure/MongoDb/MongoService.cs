using System;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        public MongoService(IOptions<MongoDbSettings> options)
        {
            ArgumentNullException.ThrowIfNull(options);
            ArgumentNullException.ThrowIfNull(options.Value);
            ArgumentNullException.ThrowIfNull(options.Value.ConnectionString);
            ArgumentNullException.ThrowIfNull(options.Value.MongoDbDatabaseName);

            MongoClient = new MongoClient(options.Value.ConnectionString);
            Database = MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);
        }

        public MongoClient MongoClient { get; }

        public IMongoDatabase Database { get; }
    }
}
