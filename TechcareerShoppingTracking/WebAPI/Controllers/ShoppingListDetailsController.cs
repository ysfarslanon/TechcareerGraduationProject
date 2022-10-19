using Business.Abstract;
using Entities.Dtos.ShoppingListDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Normal")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListDetailsController : ControllerBase
    {
        private readonly IShoppingListDetailService _shoppingListDetailService;

        public ShoppingListDetailsController(IShoppingListDetailService shoppingListDetailService)
        {
            _shoppingListDetailService = shoppingListDetailService;
        }
        [HttpPost]
        public IActionResult Add(ShoppingListDetailAddDto shoppingListDetailAddDto)
        {
            bool result = _shoppingListDetailService.Add(shoppingListDetailAddDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Created("", result);
        }

        [HttpPut]
        public IActionResult Update(ShoppingListDetailUpdateDto shoppingListDetailUpdateDto)
        {
            bool result = _shoppingListDetailService.Update(shoppingListDetailUpdateDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(ShoppingListDetailDeleteDto shoppingListDetailDeleteDto)
        {
            bool result = _shoppingListDetailService.Delete(shoppingListDetailDeleteDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _shoppingListDetailService.GetAllWithDetail();

            if (results is null)
            {
                return NotFound(results);
            }
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _shoppingListDetailService.GetByIdWithDetail(id);

            if (result is null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("listDetail")]
        public IActionResult GetByShoppingListId([FromQuery] int shoppingListId)
        {
            var result = _shoppingListDetailService.GetAllWithDetailByShoppingListId(shoppingListId);

            if (result is null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPatch("changeisboughtstate")]
        public IActionResult ChangeIsBoughtState(ShoppingListDetailChangeIsBoughtDto shoppingListDetailChangeIsBoughtDto)
        {
            var result = _shoppingListDetailService.ChangeIsBought(shoppingListDetailChangeIsBoughtDto);

            if (!result) return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("changedescriptionstate")]
        public IActionResult ChangeDescriptionState(ShoppingListDetailChangeDescriptionDto shoppingListDetailChangeDescriptionDto)
        {
            var result = _shoppingListDetailService.ChangeDescription(shoppingListDetailChangeDescriptionDto);

            if (!result) return BadRequest(result);

            return Ok(result);
        }
    }
}
