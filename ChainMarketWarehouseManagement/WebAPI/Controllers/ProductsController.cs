using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addProduct")]
        public IActionResult Add(AddProductDto addProductDto)
        {
            var result = _productService.Add(addProductDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("updateProducts/{id}")]
        public IActionResult Update(UpdateProductDto updateProductDto, int id)
        {
            var result = _productService.Update(updateProductDto, id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getAllProducts")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }

        [HttpGet("getProductbyId")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.IsSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("getbyunitprice")]
        public IActionResult GetByUnitPrice(int minPrice, int maxPrice)
        {
            var result = _productService.GetByUnitPrice(minPrice, maxPrice);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}