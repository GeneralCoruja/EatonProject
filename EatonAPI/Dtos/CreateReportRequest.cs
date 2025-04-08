namespace EatonAPI.Dtos;

public class CreateReportRequest
{
    public Guid DeviceId { get; set; }
    public string Message { get; set; }
}