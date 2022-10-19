using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class EfCategoryDal : EfRepositoryBase<Category, Context>, ICategoryDal
    {
        public EfCategoryDal(Context context) : base(context)
        {
        }

        public ICollection<CategoryDto> GetAllWithDetail(Expression<Func<Category, bool>> filter = null)
        {
            var categories = from c in filter == null ? Context.Categories : Context.Categories.Where(filter)
                             select new CategoryDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                             };
            return categories.ToList();
        }

        public CategoryDto GetWithDetail(Expression<Func<Category, bool>> filter)
        {
           var categories = from c in Context.Categories.Where(filter)
                          select new CategoryDto
                          {
                              Id = c.Id,
                              Name = c.Name
                          };

            return categories.ToList().ElementAt(0);
        }
    }
}
