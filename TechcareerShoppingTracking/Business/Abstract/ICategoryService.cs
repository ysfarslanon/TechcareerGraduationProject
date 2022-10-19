using Entities.Concrete;
using Entities.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        bool Add(CategoryAddDto categoryAddDto);
        bool Delete(CategoryDeleteDto categoryDeleteDto);
        bool Update(CategoryUpdateDto categoryUpdateDto);
        ICollection<CategoryDto> GetAllWithDetail();
        CategoryDto GetByIdWithDetail(int id);

        ICollection<Category> GetAll();
        Category GetById(int id);

    }
}
