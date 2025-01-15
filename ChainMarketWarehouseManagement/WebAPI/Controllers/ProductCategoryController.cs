using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpPost("addCategory")]
        public IActionResult Add(AddProductCategoryDto addProductCategoryDto)
        {
            var result = _productCategoryService.Add(addProductCategoryDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("deleteCategory/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productCategoryService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getAllCategories")]
        public IActionResult GetAll()
        {
            var result = _productCategoryService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }

        [HttpGet("getCategorybyId")]
        public IActionResult GetById(int categoryId)
        {
            var result = _productCategoryService.GetById(categoryId);
            if (result.IsSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPut("updateCategory/{id}")]
        public IActionResult Update(UpdateProductCategoryDto updateProductCategoryDto, int id)
        {
            var result = _productCategoryService.Update(updateProductCategoryDto, id);
            if (result.IsSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
