using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet("getAllWarehouses")]
        public IActionResult GetWarehouses()
        {
            var result = _warehouseService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }

        [HttpGet("getSubWarehouses")]
        public IActionResult GetSubWarehouses(int warehouseId)
        {
            var result = _warehouseService.GetSubWarehouse(warehouseId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getWarehousebyid")]
        public IActionResult GetById(int warehouseId)
        {
            var result = _warehouseService.GetById(warehouseId);
            if (result.IsSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("addWarehouse")]
        public IActionResult Add(AddWarehouseDto warehouse)
        {
            var result = _warehouseService.AddWarehouse(warehouse);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
