using EatonAPI.Dtos;
using EatonAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EatonAPI.Controllers
{
    [ApiController]
    [Route("Devices")]
    public class DeviceController : Controller
    {
        private IDeviceService _deviceService;
        
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var devices = await _deviceService.GetAllAsync();
            var result = new EnumeratedResult<Device>(devices);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var device = await _deviceService.GetByIdAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeviceRequest request)
        {
            try
            {
                var device = await _deviceService.CreateAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = device.Id }, device);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _deviceService.DeleteAsync(id);
            return NoContent();
        }
    }
}