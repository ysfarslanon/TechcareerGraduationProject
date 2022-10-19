using Business.Abstract;
using Business.ValidationRules.FluentValidation.CategoryValidators;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public bool Add(CategoryAddDto categoryAddDto)
        {
            CategoryAddDtoValidator validationRules = new CategoryAddDtoValidator();
            var validResult = validationRules.Validate(categoryAddDto);

            if (!validResult.IsValid) return false;
            if (!IsCategoryNameAvaibleToAddOrUpdate(categoryAddDto.Name)) return false;

            Category addedCategory = new Category();
            addedCategory.Name = categoryAddDto.Name;

            _categoryDal.Add(addedCategory);
            return true;
        }

        public bool Delete(CategoryDeleteDto categoryDeleteDto)
        {

            CategoryDeleteDtoValidator validationRules = new CategoryDeleteDtoValidator();
            var validResult = validationRules.Validate(categoryDeleteDto);

            if (!validResult.IsValid) return false;
            if (!IsCategoryExist(categoryDeleteDto.Id)) return false;

            Category deletedCategory = _categoryDal.Get(c => c.Id == categoryDeleteDto.Id);

            _categoryDal.Delete(deletedCategory);
            return true;
        }

        public ICollection<Category> GetAll()
        {
            return new List<Category>(_categoryDal.GetAll());
        }

        public ICollection<CategoryDto> GetAllWithDetail()
        {
            return new List<CategoryDto>(_categoryDal.GetAllWithDetail());
        }

        public Category GetById(int id)
        {
            if (!IsCategoryExist(id)) return null;

            return _categoryDal.Get(c => c.Id == id);
        }

        public CategoryDto GetByIdWithDetail(int id)
        {
            if (!IsCategoryExist(id)) return null;

            return _categoryDal.GetWithDetail(c => c.Id == id);
        }

        public bool Update(CategoryUpdateDto categoryUpdateDto)
        {
            CategoryUpdateDtoValidator validationRules = new CategoryUpdateDtoValidator();
            var validResults = validationRules.Validate(categoryUpdateDto);

            if (!validResults.IsValid) return false;
            if (!IsCategoryExist(categoryUpdateDto.Id)) return false;
            if (!IsCategoryNameAvaibleToAddOrUpdate(categoryUpdateDto.Name)) return false;

            Category updatedCategory = new Category();
            updatedCategory.Id = categoryUpdateDto.Id;
            updatedCategory.Name = categoryUpdateDto.Name;

            _categoryDal.Update(updatedCategory);
            return true;
        }


        // ------------------ BUSINESS RULES ------------------

        private bool IsCategoryExist(int categoryId)
        {
            Category category = _categoryDal.Get(c => c.Id == categoryId);
            if (category is not null)
            {
                return true;
            }
            return false;
        }

        private bool IsCategoryNameAvaibleToAddOrUpdate(string categoryName)
        {
            var category = _categoryDal.Get(c => c.Name.ToLower() == categoryName.ToLower());
            if (category is not null)
            {
                return false;
            }
            return true;
        }

    }
}
