using EatonAPI.Database.Entities;
using MongoDB.Driver;

namespace EatonAPI.Database.Clients
{
    public class DeviceClient : DBClient<Device>
    {
        public DeviceClient(IMongoCollection<Device> deviceCollection)
            : base(deviceCollection)
        {
        }
        
        // get all devices
        public async Task<List<Device>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        // get device by id
        public async Task<Device> GetByIdAsync(Guid id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        // create new devices
        public async Task CreateAsync(Device newDevice) =>
            await _collection.InsertOneAsync(newDevice);
        
        // delete existing device
        public async Task DeleteAsync(Guid id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}