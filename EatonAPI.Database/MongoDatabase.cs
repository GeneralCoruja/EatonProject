namespace EatonAPI.Database
{
    using EatonAPI.Database.Clients;
    using EatonAPI.Database.Entities;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    public class MongoDatabase
    {
        public DeviceClient Devices { get; set; }

        public MongoDatabase(IOptions<DatabaseSettings> DatabaseSettings)
        {
            var mongoClient = new MongoClient(
                DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(DatabaseSettings.Value.DatabaseName);

            InitializeClients(DatabaseSettings, mongoDatabase);
        }

        private void InitializeClients(IOptions<DatabaseSettings> settings, IMongoDatabase database)
        {
            Devices = new DeviceClient(database.GetCollection<Device>(settings.Value.DevicesCollection));
        }
    }
}