using Business.Abstract;
using Business.ValidationRules.FluentValidation.CategoryValidators;
using Entities.Concrete;
using Entities.Dtos.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(CategoryAddDto categoryAddDto)
        {
            bool result = _categoryService.Add(categoryAddDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Created("", result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update(CategoryUpdateDto categoryUpdateDto)
        {
            bool result = _categoryService.Update(categoryUpdateDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete(CategoryDeleteDto categoryDeleteDto)
        {
            bool result = _categoryService.Delete(categoryDeleteDto);
         
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
            var results = _categoryService.GetAllWithDetail();

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
            var result = _categoryService.GetByIdWithDetail(id);

            if (result is null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
