using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class EfProductDal : EfRepositoryBase<Product, Context>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
        }

        public ICollection<ProductDto> GetAllWithDetail(Expression<Func<Product, bool>> filter = null)
        {
            var result = from p in filter == null ? Context.Products : Context.Products.Where(filter)
                         join c in Context.Categories
                         on p.CategoryId equals c.Id
                         select new ProductDto
                         {
                             Id = p.Id,
                             CategoryId = c.Id,
                             CategoryName = c.Name,
                             Name = p.Name,
                             PictureURL = p.PictureURL
                         };

            return result.ToList();
        }

        public ProductDto GetWithDetail(Expression<Func<Product, bool>> filter)
        {

            var result = Context.Products
                .Include(p => p.Category)
                .Where(filter)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    CategoryId = p.Category.Id,
                    CategoryName = p.Category.Name,
                    Name = p.Name,
                    PictureURL = p.PictureURL
                })
                .SingleOrDefault();


            return result;
        }

        
    }



   

}
