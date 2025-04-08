using EatonAPI.Dtos;
using EatonAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EatonAPI.Controllers
{
    [ApiController]
    [Route("Reports")]
    public class ReportController : Controller
    {
        private IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid? deviceId = null)
        {
            var reports = await _reportService.GetAllAsync(deviceId);
            var result = new EnumeratedResult<Report>(reports);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var report = await _reportService.GetByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReportRequest request)
        {
            try
            {
                var newReport = await _reportService.CreateAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = newReport.Id }, newReport);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}