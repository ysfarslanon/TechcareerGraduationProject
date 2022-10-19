using Business.Abstract;
using Business.ValidationRules.FluentValidation.ProductValidators;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public bool Add(ProductAddDto productAddDto)
        {
            ProductAddDtoValidator validationRules = new ProductAddDtoValidator();
            var validResult = validationRules.Validate(productAddDto);

            if (!validResult.IsValid) return false;
            if (!IsCategoryExist(productAddDto.CategoryId)) return false;
            if (!IsProductNameAvaibleToAddOrUpdate(productAddDto.Name)) return false;

            Product addedProduct = new Product();
            addedProduct.Name = productAddDto.Name;
            addedProduct.PictureURL = productAddDto.PictureURL;
            addedProduct.CategoryId = productAddDto.CategoryId;

            _productDal.Add(addedProduct);
            return true;
        }

        public bool Delete(ProductDeleteDto productDeleteDto)
        {
            ProductDeleteDtoValidator validationRules = new ProductDeleteDtoValidator();
            var validResults = validationRules.Validate(productDeleteDto);

            if (!validResults.IsValid) return false;
            if (!IsProductExist(productDeleteDto.Id)) return false;

            Product deletedProduct = _productDal.Get(p => p.Id == productDeleteDto.Id);

            _productDal.Delete(deletedProduct);
            return true;
        }

        public ICollection<Product> GetAll()
        {
            return new List<Product>(_productDal.GetAll());
        }

        public ICollection<ProductDto> GetAllWithDetail()
        {
            return new List<ProductDto>(_productDal.GetAllWithDetail());
        }

        public ICollection<ProductDto> GetAllWithDetailByCategoryId(int categoryId)
        {
            if (!IsCategoryExist(categoryId)) return null;

            return new List<ProductDto>(_productDal.GetAllWithDetail(p => p.CategoryId == categoryId));
        }

        public Product GetById(int id)
        {
            if (!IsProductExist(id)) return null;

            return _productDal.Get(p => p.Id == id);
        }

        public ProductDto GetByIdWithDetail(int id)
        {
            if (!IsProductExist(id)) return null;

            return _productDal.GetWithDetail(p => p.Id == id);
        }

        public bool Update(ProductUpdateDto productUpdateDto)
        {
            ProductUpdateDtoValidator validationRules = new ProductUpdateDtoValidator();
            var validResult = validationRules.Validate(productUpdateDto);

            if (!validResult.IsValid) return false;
            if (!IsProductExist(productUpdateDto.Id)) return false;
            if (!IsCategoryExist(productUpdateDto.CategoryId)) return false;
            if (!IsProductNameAvaibleToAddOrUpdate(productUpdateDto.Name)) return false;

            Product updatedProduct = new Product();
            updatedProduct.Id = productUpdateDto.Id;
            updatedProduct.Name = productUpdateDto.Name;
            updatedProduct.CategoryId = productUpdateDto.CategoryId;
            updatedProduct.PictureURL = productUpdateDto.PictureURL;

            _productDal.Update(updatedProduct);
            return true;
        }


        // ------------------ BUSINESS RULES ------------------

        private bool IsCategoryExist(int categoryId)
        {
            Category category = _categoryService.GetById(categoryId);
            if (category is not null)
            {
                return true;
            }
            return false;
        }
        private bool IsProductExist(int productId)
        {
            Product product = _productDal.Get(p => p.Id == productId);
            if (product is not null)
            {
                return true;
            }
            return false;
        }

        private bool IsProductNameAvaibleToAddOrUpdate(string productName)
        {
            var product = _productDal.Get(c => c.Name.ToLower() == productName.ToLower());
            if (product is not null)
            {
                return false;
            }
            return true;
        }

    }
}
