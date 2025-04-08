using EatonAPI.Database;
using EatonAPI.Services.Extensions;
using EatonAPI.Models;
using EatonAPI.Services.Validators;

namespace EatonAPI.Services;

public class DeviceService : IDeviceService
{
    private MongoDatabase _database;
    public DeviceService(MongoDatabase database)
    {
        _database = database;
    }

    public async Task<List<Device>> GetAllAsync()
    {
        var result = await _database.Devices.GetAllAsync();
        return result.Select(x => x.ToDto()).ToList();
    }

    public async Task<Device> GetByIdAsync(Guid id)
    {
        var result = await _database.Devices.GetByIdAsync(id);
        return result?.ToDto();
    }

    public async Task<Device> CreateAsync(CreateDeviceRequest request)
    {
        // validate request
        DeviceValidator.ValidateCreateDeviceRequest(request);
        
        // create new device
        var newDevice = new Device
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
        };
        
        await _database.Devices.CreateAsync(newDevice.ToEntity());
        return newDevice;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _database.Devices.DeleteAsync(id);
    }
}