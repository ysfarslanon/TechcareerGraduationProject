using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IShoppingListDal : IRepository<ShoppingList>
    {
        ICollection<ShoppingListDto> GetAllWithDetail();
        ShoppingListDto GetWithDetail(Expression<Func<ShoppingList, bool>> filter);
        ICollection<ShoppingListDto> GetAllWithDetail(Expression<Func<ShoppingList, bool>> filter);
    }
}
