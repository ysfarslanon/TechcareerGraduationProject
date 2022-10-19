using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Products;
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
    public class EfShoppingListDal : EfRepositoryBase<ShoppingList, Context>, IShoppingListDal
    {
        public EfShoppingListDal(Context context) : base(context)
        {
        }


        public ICollection<ShoppingListDto> GetAllWithDetail()
        {
            var results = Context.ShoppingLists
               .Include(p => p.User)
               .Include(p => p.ShoppingListDetails)
               .ThenInclude(a => a.Product)
               .OrderByDescending(p => p.CreatedDate)
               .Select(p => new ShoppingListDto
               {
                   ShoppingListId = p.Id,
                   IsShopping = p.IsShopping,
                   ShoppingListName = p.Name,
                   UserFullName = $"{p.User.FirstName} {p.User.LastName}",
                   Details = p.ShoppingListDetails
                   .Select(b => new ShoppingListDetailDto
                   {
                       ShoppingListDetailId = b.Id,
                       ListName = b.ShoppingList.Name,
                       ProductId = b.ProductId,
                       ProductName = b.Product.Name,
                       ProductPictureURL = b.Product.PictureURL,
                       Description = b.Description,
                       IsBought = b.IsBought
                   }).ToList()
               });

            return results.ToList();
        }

        public ShoppingListDto GetWithDetail(Expression<Func<ShoppingList, bool>> filter)
        {
             var results = Context.ShoppingLists
                .Include(p => p.User)
                .Include(p => p.ShoppingListDetails)
                .ThenInclude(a => a.Product)
                .Where(filter)
                .Select(p => new ShoppingListDto
                {
                    ShoppingListId = p.Id,
                    IsShopping = p.IsShopping,
                    ShoppingListName = p.Name,
                    UserFullName = $"{p.User.FirstName} {p.User.LastName}",
                    Details = p.ShoppingListDetails
                    .Select(b => new ShoppingListDetailDto
                    {
                        ShoppingListDetailId = b.Id,
                        ListName = b.ShoppingList.Name,
                        ProductId = b.ProductId,
                        ProductName = b.Product.Name,
                        ProductPictureURL = b.Product.PictureURL,
                        Description = b.Description,
                        IsBought = b.IsBought
                    }).ToList()
                }).SingleOrDefault();

            return results;
        }

        public ICollection<ShoppingListDto> GetAllWithDetail(Expression<Func<ShoppingList, bool>> filter)
        {
            var results = Context.ShoppingLists
                .Include(p => p.User)
                .Include(p => p.ShoppingListDetails)
                .ThenInclude(a => a.Product)
                .Where(filter)
                .OrderByDescending(p => p.CreatedDate)
                .Select(p => new ShoppingListDto
                {
                    ShoppingListId = p.Id,
                    IsShopping = p.IsShopping,
                    ShoppingListName = p.Name,
                    UserFullName = $"{p.User.FirstName} {p.User.LastName}",
                    Details = p.ShoppingListDetails
                    .Select(b => new ShoppingListDetailDto
                    {
                        ShoppingListDetailId = b.Id,
                        ListName = b.ShoppingList.Name,
                        ProductId = b.ProductId,
                        ProductName = b.Product.Name,
                        ProductPictureURL = b.Product.PictureURL,
                        Description = b.Description,
                        IsBought = b.IsBought
                    }).ToList()
                });

            return results.ToList();
        }
      


    }


}
