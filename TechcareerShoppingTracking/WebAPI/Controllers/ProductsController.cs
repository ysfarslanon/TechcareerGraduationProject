using Business.Abstract;
using Entities.Dtos.Categories;
using Entities.Dtos.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(ProductAddDto productAddDto)
        {
            bool result = _productService.Add(productAddDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Created("", result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update(ProductUpdateDto productUpdateDto)
        {
            bool result = _productService.Update(productUpdateDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete(ProductDeleteDto productDeleteDto)
        {
            bool result = _productService.Delete(productDeleteDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _productService.GetAllWithDetail();

            if (results is null)
            {
                return NotFound(results);
            }
            return Ok(results);
        }

        [Authorize]
        [HttpGet("category/{categoryId}")]
        public IActionResult GetAllByCategoryId(int categoryId)
        {
            var results = _productService.GetAllWithDetailByCategoryId(categoryId);

            if (results is null)
            {
                return NotFound(results);
            }
            return Ok(results);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetByIdWithDetail(id);

            if (result is null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
