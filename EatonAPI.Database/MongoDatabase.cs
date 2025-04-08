using EatonAPI.Database.Clients;
using EatonAPI.Database.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EatonAPI.Database
{
    public class MongoDatabase
    {
        public DeviceClient Devices { get; set; }
        public ReportClient Reports { get; set; }

        public MongoDatabase(IOptions<DatabaseSettings> DatabaseSettings)
        {
            var mongoClient = new MongoClient(
                DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(DatabaseSettings.Value.DatabaseName);
            Console.WriteLine($"TRYING TO CONNECT TO DB ON {DatabaseSettings.Value.ConnectionString}");
            InitializeClients(DatabaseSettings, mongoDatabase);
        }

        private void InitializeClients(IOptions<DatabaseSettings> settings, IMongoDatabase database)
        {
            Devices = new DeviceClient(database.GetCollection<Device>(settings.Value.DevicesCollection));
            Reports = new ReportClient(database.GetCollection<Report>(settings.Value.ReportsCollection));
        }
    }
}