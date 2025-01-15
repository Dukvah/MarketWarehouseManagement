using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("getAllStocks")]
        public IActionResult GetAllStocks()
        {
            var result = _stockService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }

        [HttpGet("getStockbyid")]
        public IActionResult GetById(int stockId)
        {
            var result = _stockService.GetById(stockId);
            if (result.IsSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("addStock")]
        public IActionResult Add(AddStockDto stock)
        {
            var result = _stockService.AddStock(stock);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("TransferStock")]
        public IActionResult TransferStock(AddStockDto stock)
        {
            var result = _stockService.TransferStock(stock);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
