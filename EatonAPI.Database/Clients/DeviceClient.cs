namespace EatonAPI.Database.Clients
{
    using EatonAPI.Database.Entities;
    using MongoDB.Driver;

    public class DeviceClient : DBClient<Device>
    {
        public DeviceClient(IMongoCollection<Device> deviceCollection)
            : base(deviceCollection)
        {
        }
        
        // get all objectives
        public async Task<List<Device>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        // create new objectives
        public async Task CreateAsync(Device newDevice) =>
            await _collection.InsertOneAsync(newDevice);
    }
}