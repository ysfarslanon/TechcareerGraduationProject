using Business.Abstract;
using Entities.Dtos.Products;
using Entities.Dtos.ShoppingLists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DataAccess.Concrete.Repositories.EfShoppingListDal;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Normal")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListsController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpPost]
        public IActionResult Add(ShoppingListAddDto shoppingListAddDto)
        {
            bool result = _shoppingListService.Add(shoppingListAddDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Created("", result);
        }

        [HttpPut]
        public IActionResult Update(ShoppingListUpdateDto shoppingListUpdateDto)
        {
            bool result = _shoppingListService.Update(shoppingListUpdateDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(ShoppingListDeleteDto shoppingListDeleteDto)
        {
            bool result = _shoppingListService.Delete(shoppingListDeleteDto);

            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _shoppingListService.GetAllWithDetail();

            if (results is null)
            {
                return NotFound(results);
            }
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _shoppingListService.GetByIdWithDetail(id);

            if (result is null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("list")]
        public IActionResult GetByUserId([FromQuery] int userId)
        {
            var result = _shoppingListService.GetAllWithDetailByUserId(userId);

            if (result is null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPatch("changeisshoppingstate")]
        public IActionResult ChangeIsShoppingState(ShoppingListChangeIsShoppingDto shoppingListChangeIsShoppingDto)
        {
            var result = _shoppingListService.ChangeIsShopping(shoppingListChangeIsShoppingDto);

            if (!result) return BadRequest(result);

            return Ok(result);
        }

       
     
    }
}
