using EatonAPI.Models;

namespace EatonAPI.Services
{
    public interface IDeviceService
    {
        public Task<List<Device>> GetAllAsync();
        public Task<Device> GetByIdAsync(Guid id);
        public Task<Device> CreateAsync(CreateDeviceRequest request);
        public Task DeleteAsync(Guid id);        
    }
}