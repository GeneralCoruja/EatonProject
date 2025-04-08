using Model = EatonAPI.Dtos;
using Entity = EatonAPI.Database.Entities;

namespace EatonAPI.Services.Extensions
{
    public static class DeviceMapper
    {
        public static Model.Device ToDto(this Entity.Device device)
        {
            return new Model.Device
            {
                Id = device.Id,
                Name = device.Name,
                CreatedDate = device.CreatedDate,
                UpdatedDate = device.UpdatedDate,
            };
        }

        public static Entity.Device ToEntity(this Model.Device device)
        {
            return new Entity.Device
            {
                Id = device.Id,
                Name = device.Name,
                CreatedDate = device.CreatedDate,
                UpdatedDate = device.UpdatedDate,
            };
        }
    }
}