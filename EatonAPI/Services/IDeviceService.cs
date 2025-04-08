using EatonAPI.Models;

namespace EatonAPI.Services
{
    public interface IDeviceService
    {
        public IEnumerable<Device> GetAllAsync();
    }
}