using CRUD.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPRO : ControllerBase
    {
        private readonly ICRUDService _service;
        private readonly ILogger<OrderPRO> _Logger;

        public OrderPRO(ICRUDService service,ILogger<OrderPRO> logger)
        {
            _service=service;
            _Logger =logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders(
           int pageNumber = 1,
           int pageSize = 1940)
        {
            var data = await _service
                
                .GetAllData(pageNumber, pageSize);
            _Logger.LogInformation("All Data show");

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var data = await _service.orderId(id);

            if (data == null)
            {
                return NotFound("User Is Not Found");
            }

            return Ok(data);
        }

    }
}
