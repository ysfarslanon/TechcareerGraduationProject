using Business.Abstract;
using Business.ValidationRules.FluentValidation.ShoppingListDetailValidators;
using Business.ValidationRules.FluentValidation.ShoppingListValidators;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Entities.Dtos.ShoppingListDetails;
using Entities.Dtos.ShoppingLists;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShoppingListDetailManager : IShoppingListDetailService
    {
        private readonly IShoppingListDetailDal _shoppingListDetailDal;
        private readonly IShoppingListService _shoppingListService;
        private readonly IProductService _productService;

        public ShoppingListDetailManager(IShoppingListDetailDal shoppingListDetailDal, IShoppingListService shoppingListService, IProductService productService)
        {
            _shoppingListDetailDal = shoppingListDetailDal;
            _shoppingListService = shoppingListService;
            _productService = productService;
        }

        public bool Add(ShoppingListDetailAddDto shoppingListDetailAddDto)
        {
            ShoppingListDetailAddDtoValidator validationRules = new ShoppingListDetailAddDtoValidator();
            var validResult = validationRules.Validate(shoppingListDetailAddDto);

            if (!validResult.IsValid) return false;
            if (!IsShoppingListExist(shoppingListDetailAddDto.ShoppingListId)) return false;
            if (!IsProductExist(shoppingListDetailAddDto.ProductId)) return false;
            if (!IsShoppingListDetailCanBeEditable(shoppingListDetailAddDto.ShoppingListId)) return false;

            ShoppingListDetail addedShoppingListDetail = new ShoppingListDetail();
            addedShoppingListDetail.ShoppingListId = shoppingListDetailAddDto.ShoppingListId;
            addedShoppingListDetail.IsBought = shoppingListDetailAddDto.IsBought;
            addedShoppingListDetail.Description = shoppingListDetailAddDto.Description;
            addedShoppingListDetail.ProductId = shoppingListDetailAddDto.ProductId;

            _shoppingListDetailDal.Add(addedShoppingListDetail);
            return true;
        }

        public bool Delete(ShoppingListDetailDeleteDto shoppingListDetailDeleteDto)
        {
            ShoppingListDetailDeleteDtoValidator validationRules = new ShoppingListDetailDeleteDtoValidator();
            var validResult = validationRules.Validate(shoppingListDetailDeleteDto);

            if (!validResult.IsValid) return false;
            if (!IsShoppingListDetailExist(shoppingListDetailDeleteDto.Id)) return false;

            ShoppingListDetail deletedShoppingListDetail = new ShoppingListDetail();
            deletedShoppingListDetail.Id = shoppingListDetailDeleteDto.Id;

            _shoppingListDetailDal.Delete(deletedShoppingListDetail);
            return true;
        }

        public ICollection<ShoppingListDetail> GetAll()
        {
            return new List<ShoppingListDetail>(_shoppingListDetailDal.GetAll());
        }

        public ICollection<ShoppingListDetailDto> GetAllWithDetail()
        {
            return new List<ShoppingListDetailDto>(_shoppingListDetailDal.GetAllWithDetail());
        }

        public ICollection<ShoppingListDetailDto> GetAllWithDetailByShoppingListId(int shoppingListId)
        {
            if (!IsShoppingListExist(shoppingListId)) return null;

            return new List<ShoppingListDetailDto>(_shoppingListDetailDal.GetAllWithDetail(p => p.ShoppingListId == shoppingListId));
        }

        public ShoppingListDetail GetById(int id)
        {
            if (!IsShoppingListDetailExist(id)) return null;

            return _shoppingListDetailDal.Get(p => p.Id == id);
        }

        public ShoppingListDetailDto GetByIdWithDetail(int id)
        {
            if (!IsShoppingListDetailExist(id)) return null;

            return _shoppingListDetailDal.GetWithDetail(p => p.Id == id);
        }

        public bool Update(ShoppingListDetailUpdateDto shoppingListDetailUpdateDto)
        {
            ShoppingListDetailUpdateDtoValidator validationRules = new ShoppingListDetailUpdateDtoValidator();
            var validResult = validationRules.Validate(shoppingListDetailUpdateDto);

            if (!validResult.IsValid) return false;
            if (!IsShoppingListDetailExist(shoppingListDetailUpdateDto.Id)) return false;
            if (!IsShoppingListExist(shoppingListDetailUpdateDto.ShoppingListId)) return false;
            if (!IsProductExist(shoppingListDetailUpdateDto.ProductId)) return false;
            if (!IsShoppingListDetailCanBeEditable(shoppingListDetailUpdateDto.ShoppingListId)) return false;

            ShoppingListDetail updatedShoppingListDetail = _shoppingListDetailDal.Get(p => p.Id == shoppingListDetailUpdateDto.Id);
            updatedShoppingListDetail.ShoppingListId = updatedShoppingListDetail.ShoppingListId;
            updatedShoppingListDetail.IsBought = updatedShoppingListDetail.IsBought;
            updatedShoppingListDetail.Description = updatedShoppingListDetail.Description;
            updatedShoppingListDetail.ProductId = updatedShoppingListDetail.ProductId;

            _shoppingListDetailDal.Update(updatedShoppingListDetail);
            return true;
        }
        public bool ChangeIsBought(ShoppingListDetailChangeIsBoughtDto shoppingListDetailChangeIsBoughtDto)
        {
            ShoppingListDetailChangeIsBoughtDtoValidator validationRules = new ShoppingListDetailChangeIsBoughtDtoValidator();
            var validResult = validationRules.Validate(shoppingListDetailChangeIsBoughtDto);

            if (!validResult.IsValid) return false;
            if (!IsShoppingListDetailExist(shoppingListDetailChangeIsBoughtDto.Id)) return false;

            ShoppingListDetail changedShoppingListDetail = _shoppingListDetailDal.Get(p => p.Id == shoppingListDetailChangeIsBoughtDto.Id);
            changedShoppingListDetail.IsBought = shoppingListDetailChangeIsBoughtDto.IsBought;

            _shoppingListDetailDal.Update(changedShoppingListDetail);
            return true;
        }

        public bool ChangeDescription(ShoppingListDetailChangeDescriptionDto shoppingListDetailChangeDescriptionDto)
        {
            ShoppingListDetailChangeDescriptionDtoValidator validationRules = new ShoppingListDetailChangeDescriptionDtoValidator();
            var validResult = validationRules.Validate(shoppingListDetailChangeDescriptionDto);

            if (!validResult.IsValid) return false;
            if (!IsShoppingListDetailExist(shoppingListDetailChangeDescriptionDto.Id)) return false;

            ShoppingListDetail changedShoppingListDetail = _shoppingListDetailDal.Get(p => p.Id == shoppingListDetailChangeDescriptionDto.Id);
            changedShoppingListDetail.Description = shoppingListDetailChangeDescriptionDto.Description;

            _shoppingListDetailDal.Update(changedShoppingListDetail);
            return true;
        }

        // ------------------ BUSINESS RULES ------------------

        private bool IsShoppingListDetailExist(int shoppingListDetailId)
        {
            ShoppingListDetail shoppingListDetail = _shoppingListDetailDal.Get(p => p.Id == shoppingListDetailId);
            if (shoppingListDetail is not null)
            {
                return true;
            }
            return false;
        }
        private bool IsShoppingListExist(int shoppingListId)
        {
            ShoppingList shoppingList = _shoppingListService.GetById(shoppingListId);
            if (shoppingList is not null)
            {
                return true;
            }
            return false;
        }

        private bool IsProductExist(int productId)
        {
            Product product = _productService.GetById(productId);
            if (product is not null)
            {
                return true;
            }
            return false;
        }

        private bool IsShoppingListDetailCanBeEditable(int shoppingListId)
        {
            bool isShopping = _shoppingListService.GetById(shoppingListId).IsShopping;
            if (isShopping)
            {
                return false;
            }
            return true;
        }

       
    }
}
