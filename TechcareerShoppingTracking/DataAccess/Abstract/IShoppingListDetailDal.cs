using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.ShoppingListDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IShoppingListDetailDal : IRepository<ShoppingListDetail>
    {
        ICollection<ShoppingListDetailDto> GetAllWithDetail(Expression<Func<ShoppingListDetail, bool>> filter = null);
        ShoppingListDetailDto GetWithDetail(Expression<Func<ShoppingListDetail, bool>> filter);

    }
}
