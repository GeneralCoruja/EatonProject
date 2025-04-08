using EatonAPI.Models;

namespace EatonAPI.Services.Validators
{
    public static class DeviceValidator
    {
        private const int _NameMaxLength = 24;
        
        public static void ValidateCreateDeviceRequest(CreateDeviceRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Name == null)
            {
                throw new ArgumentNullException("request.Name");
            }

            if (request.Name.Length == 0)
            {
                throw new ArgumentException("Name must not be empty", "request.Name");
            }

            if (request.Name.Length > _NameMaxLength)
            {
                throw new ArgumentException($"Name cannot be longer than {_NameMaxLength} characters", "request.Name");
            }
        }
    }
}