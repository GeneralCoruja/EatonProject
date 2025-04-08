using EatonAPI.Database;
using EatonAPI.Dtos;
using EatonAPI.Services.Extensions;
using EatonAPI.Services.Validators;

namespace EatonAPI.Services;

public class ReportService : IReportService
{
    private MongoDatabase _database;
    
    public ReportService(MongoDatabase database)
    {
        _database = database;
    }
    
    public async Task<List<Report>> GetAllAsync(Guid? deviceId = null)
    {
       var reports = await _database.Reports.GetAllAsync(deviceId);
       return reports.Select(x => x.ToDto()).ToList();
    }

    public async Task<Report> GetByIdAsync(Guid id)
    {
        var report = await _database.Reports.GetByIdAsync(id);
        return report?.ToDto();
    }

    public async Task<Report> CreateAsync(CreateReportRequest request)
    {
        // validate the report request
        request.Validate();
        
        // create new report
        var newReport = new Report
        {
            Id = Guid.NewGuid(),
            DeviceId = request.DeviceId,
            Message = request.Message,
            CreatedDate = DateTime.UtcNow,
        };
        await _database.Reports.CreateAsync(newReport.ToEntity());
        return newReport;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _database.Reports.DeleteAsync(id);
    }
}