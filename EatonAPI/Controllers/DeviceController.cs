using EatonAPI.Models;
using EatonAPI.Services;
using Microsoft.AspNetCore.Http.Extensions;
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
            var result = await _deviceService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _deviceService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice(CreateDeviceRequest request)
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
        public async Task<IActionResult> DeleteDevice(Guid id)
        {
            _deviceService.DeleteAsync(id);
            return NoContent();
        }
    }
}