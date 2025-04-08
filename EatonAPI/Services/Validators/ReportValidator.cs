using EatonAPI.Dtos;

namespace EatonAPI.Services.Validators
{
    public static class ReportValidator
    {
        private const int MaxMessageLength = 60;
        
        public static void Validate(this CreateReportRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Message == null)
            {
                throw new ArgumentNullException("request.Message");
            }

            if (request.Message.Length == 0)
            {
                throw new ArgumentException("Message must not be empty", "request.Message");
            }

            if (request.Message.Length > MaxMessageLength)
            {
                throw new ArgumentException($"Message cannot be longer than {MaxMessageLength} characters", "request.Message");
            }
            
            if (request.DeviceId == Guid.Empty)
            {
                throw new ArgumentException("DeviceId must be a valid Guid", "request.DeviceId");
            }
        }
    }
}