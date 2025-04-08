namespace EatonAPI.Dtos
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}