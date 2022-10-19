
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        ICollection<CategoryDto> GetAllWithDetail(Expression<Func<Category, bool>> filter = null);
        CategoryDto GetWithDetail(Expression<Func<Category, bool>> filter);
    }
}
