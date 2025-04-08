using EatonAPI.Database.Entities;
using MongoDB.Driver;

namespace EatonAPI.Database.Clients
{
    public class ReportClient : DBClient<Report>
    {
        public ReportClient(IMongoCollection<Report> collection)
            : base(collection)
        {
        }
        
        // get all reports
        public async Task<List<Report>> GetAllAsync(Guid? deviceId = null){
            if (deviceId != null)
            {
                return await _collection.Find(x => x.DeviceId.Equals(deviceId)).ToListAsync();
            }
            else
            {
                return await _collection.Find(_ => true).ToListAsync();
            }
        }

        // get report by id
        public async Task<Report> GetByIdAsync(Guid id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        // create new report
        public async Task CreateAsync(Report newReport) =>
            await _collection.InsertOneAsync(newReport);
        
        // delete existing report
        public async Task DeleteAsync(Guid id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}