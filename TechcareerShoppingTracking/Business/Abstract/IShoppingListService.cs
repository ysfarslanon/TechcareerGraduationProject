using Entities.Concrete;
using Entities.Dtos.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Concrete.Repositories.EfShoppingListDal;

namespace Business.Abstract
{
    public interface IShoppingListService
    {
        bool Add(ShoppingListAddDto shoppingListAddDto);
        bool Delete(ShoppingListDeleteDto shoppingListDelete);
        bool Update(ShoppingListUpdateDto shoppingListUpdateDto);
        ICollection<ShoppingListDto> GetAllWithDetail();
        ShoppingListDto GetByIdWithDetail(int id);
        ICollection<ShoppingList> GetAll();
        ShoppingList GetById(int id);
        ICollection<ShoppingListDto> GetAllWithDetailByUserId(int userId);
        bool ChangeIsShopping(ShoppingListChangeIsShoppingDto shoppingListChangeIsShoppingDto);
 
    }
}
