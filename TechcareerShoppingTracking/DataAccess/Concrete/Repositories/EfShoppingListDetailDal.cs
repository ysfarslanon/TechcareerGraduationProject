using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.ShoppingListDetails;
using Entities.Dtos.ShoppingLists;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class EfShoppingListDetailDal : EfRepositoryBase<ShoppingListDetail, Context>, IShoppingListDetailDal
    {
        public EfShoppingListDetailDal(Context context) : base(context)
        {
        }

        public ICollection<ShoppingListDetailDto> GetAllWithDetail(Expression<Func<ShoppingListDetail, bool>> filter = null)
        { // TODO: Buraya shoppingListId sanki gelebilir.
            var results = from slDetail in filter == null ? Context.ShoppingListDetails : Context.ShoppingListDetails.Where(filter)
                          join sl in Context.ShoppingLists
                          on slDetail.ShoppingListId equals sl.Id
                          
                          join p in Context.Products
                          on slDetail.ProductId equals p.Id

                          orderby sl.CreatedDate descending
                          select new ShoppingListDetailDto
                          {
                              ShoppingListDetailId = slDetail.Id,
                              ListName = sl.Name,
                              ProductId = p.Id,
                              ProductName = p.Name,
                              ProductPictureURL = p.PictureURL,
                              Description = slDetail.Description,
                              IsBought = slDetail.IsBought
                          };

            return results.ToList();
        }

        public ShoppingListDetailDto GetWithDetail(Expression<Func<ShoppingListDetail, bool>> filter)
        {
            var result = Context.ShoppingListDetails
                .Include(p => p.ShoppingList)
                .Include(p => p.Product)
                .Where(filter)
                .Select(p => new ShoppingListDetailDto
                {
                    ShoppingListDetailId = p.Id,
                    ListName = p.ShoppingList.Name, 
                    ProductId = p.ProductId,
                    ProductName = p.Product.Name,
                    ProductPictureURL = p.Product.PictureURL,
                    Description = p.Description,
                    IsBought = p.IsBought
                })
                .SingleOrDefault();

            return result;
        }
    }
}
