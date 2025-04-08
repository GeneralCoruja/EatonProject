using Model = EatonAPI.Dtos;
using Entity = EatonAPI.Database.Entities;

namespace EatonAPI.Services.Extensions
{
    public static class ReportMapper
    {
        public static Model.Report ToDto(this Entity.Report report)
        {
            return new Model.Report
            {
                Id = report.Id,
                Message = report.Message,
                DeviceId = report.DeviceId,
                CreatedDate = report.CreatedDate,
            };
        }

        public static Entity.Report ToEntity(this Model.Report report)
        {
            return new Entity.Report
            {
                Id = report.Id,
                DeviceId = report.DeviceId,
                Message = report.Message,
                CreatedDate = report.CreatedDate,
            };
        }
    }
}