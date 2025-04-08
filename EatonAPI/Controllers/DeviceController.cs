using EatonAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EatonAPI.Controllers
{
    public class DeviceController : Controller
    {
        private IDeviceService _deviceService;
        
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;    
        }
        
        // GET
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_deviceService.GetAllAsync());
        }
    }
}