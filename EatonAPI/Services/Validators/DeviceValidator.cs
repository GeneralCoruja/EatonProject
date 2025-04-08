using EatonAPI.Dtos;

namespace EatonAPI.Services.Validators
{
    public static class DeviceValidator
    {
        private const int MaxNameLength = 24;
        
        public static void Validate(this CreateDeviceRequest request)
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

            if (request.Name.Length > MaxNameLength)
            {
                throw new ArgumentException($"Name cannot be longer than {MaxNameLength} characters", "request.Name");
            }
        }
    }
}