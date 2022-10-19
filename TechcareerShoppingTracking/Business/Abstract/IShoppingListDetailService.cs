
using Entities.Concrete;
using Entities.Dtos.ShoppingListDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShoppingListDetailService
    {
        bool Add(ShoppingListDetailAddDto shoppingListDetailAddDto);
        bool Delete(ShoppingListDetailDeleteDto shoppingListDetailDeleteDto);
        bool Update(ShoppingListDetailUpdateDto shoppingListDetailUpdateDto);
        ICollection<ShoppingListDetailDto> GetAllWithDetail();
        ShoppingListDetailDto GetByIdWithDetail(int id);
        ICollection<ShoppingListDetail> GetAll();
        ShoppingListDetail GetById(int id);
        ICollection<ShoppingListDetailDto> GetAllWithDetailByShoppingListId(int shoppingListId);
        bool ChangeIsBought(ShoppingListDetailChangeIsBoughtDto shoppingListDetailChangeIsBoughtDto);
        bool ChangeDescription(ShoppingListDetailChangeDescriptionDto shoppingListDetailChangeDescriptionDto);
    }
}
