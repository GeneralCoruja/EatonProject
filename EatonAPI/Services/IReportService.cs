using EatonAPI.Dtos;

namespace EatonAPI.Services
{
    public interface IReportService
    {
        public Task<List<Report>> GetAllAsync(Guid? deviceId);
        public Task<Report> GetByIdAsync(Guid id);
        public Task<Report> CreateAsync(CreateReportRequest request);
        public Task DeleteAsync(Guid id);
    }
}