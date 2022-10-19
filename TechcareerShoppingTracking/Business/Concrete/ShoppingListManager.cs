using Business.Abstract;
using Business.ValidationRules.FluentValidation.ShoppingListValidators;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Entities.Dtos.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Concrete.Repositories.EfShoppingListDal;

namespace Business.Concrete
{
    public class ShoppingListManager : IShoppingListService
    {
        private readonly IShoppingListDal _shoppingListDal;
        private readonly IUserService _userService;

        public ShoppingListManager(IShoppingListDal shoppingListDal, IUserService userService)
        {
            _shoppingListDal = shoppingListDal;
            _userService = userService;
        }

        public bool Add(ShoppingListAddDto shoppingListAddDto)
        {
            ShoppingListAddDtoValidator validationRules = new ShoppingListAddDtoValidator();
            var validResult = validationRules.Validate(shoppingListAddDto);

            if (!validResult.IsValid) return false;
            if (!IsUserExist(shoppingListAddDto.UserId)) return false;
            if (!IsShoppingListNameAvaibleToAddOrUpdate(shoppingListAddDto.Name, shoppingListAddDto.UserId)) return false;

            ShoppingList addedShoppingList = new ShoppingList();
            addedShoppingList.UserId = shoppingListAddDto.UserId;
            addedShoppingList.Name = shoppingListAddDto.Name;
            addedShoppingList.IsShopping = false;

            _shoppingListDal.Add(addedShoppingList);
            return true;
        }

        public bool Delete(ShoppingListDeleteDto shoppingListDeleteDto)
        {
            ShoppingListDeleteDtoValidator validationRules = new ShoppingListDeleteDtoValidator();
            var validResult = validationRules.Validate(shoppingListDeleteDto);

            if (!validResult.IsValid) return false;
            if (!IsShoppingListExist(shoppingListDeleteDto.Id)) return false;

            ShoppingList deletedShoppingList = new ShoppingList();
            deletedShoppingList.Id = shoppingListDeleteDto.Id;

            _shoppingListDal.Delete(deletedShoppingList);
            return true;
        }

        public ICollection<ShoppingList> GetAll()
        {
            return new List<ShoppingList>(_shoppingListDal.GetAll());
        }

        public ICollection<ShoppingListDto> GetAllWithDetail()
        {
            return new List<ShoppingListDto>(_shoppingListDal.GetAllWithDetail());
        }

        public ICollection<ShoppingListDto> GetAllWithDetailByUserId(int userId)
        {
            return new List<ShoppingListDto>(_shoppingListDal.GetAllWithDetail(p => p.UserId == userId));
        }

        public ShoppingList GetById(int id)
        {
            if (!IsShoppingListExist(id)) return null;

            return _shoppingListDal.Get(p => p.Id == id);
        }

        public ShoppingListDto GetByIdWithDetail(int id)
        {
            if (!IsShoppingListExist(id)) return null;

            return _shoppingListDal.GetWithDetail(p => p.Id == id);
        }

        public bool Update(ShoppingListUpdateDto shoppingListUpdateDto)
        {
            ShoppingListUpdateDtoValidator validationRules = new ShoppingListUpdateDtoValidator();
            var validResult = validationRules.Validate(shoppingListUpdateDto);

            if (!validResult.IsValid) return false;
            if (!IsShoppingListExist(shoppingListUpdateDto.Id)) return false;
            if (!IsUserExist(shoppingListUpdateDto.UserId)) return false;
            if (!IsShoppingListNameAvaibleToAddOrUpdate(shoppingListUpdateDto.Name, shoppingListUpdateDto.UserId)) return false;

            ShoppingList updatedShoppingList = _shoppingListDal.Get(p => p.Id == shoppingListUpdateDto.Id);
            updatedShoppingList.UserId = shoppingListUpdateDto.UserId;
            updatedShoppingList.Name = shoppingListUpdateDto.Name;
            updatedShoppingList.IsShopping = shoppingListUpdateDto.IsShopping;

            _shoppingListDal.Update(updatedShoppingList);
            return true;
        }

        public bool ChangeIsShopping(ShoppingListChangeIsShoppingDto shoppingListChangeIsShoppingDto)
        {
            ShoppingListChangeIsShoppingDtoValidator validationRules = new ShoppingListChangeIsShoppingDtoValidator();
            var validResult = validationRules.Validate(shoppingListChangeIsShoppingDto);

            if (!validResult.IsValid) return false;
            if (!IsShoppingListExist(shoppingListChangeIsShoppingDto.Id)) return false;

            ShoppingList changedShoppingList = _shoppingListDal.Get(p => p.Id == shoppingListChangeIsShoppingDto.Id);
            changedShoppingList.IsShopping = shoppingListChangeIsShoppingDto.IsShopping;

            _shoppingListDal.Update(changedShoppingList);
            return true;
        }



        // ------------------ BUSINESS RULES ------------------

        private bool IsShoppingListExist(int shoppingListId)
        {
            ShoppingList shoppingList = _shoppingListDal.Get(p => p.Id == shoppingListId);
            if (shoppingList is not null)
            {
                return true;
            }
            return false;
        }

        private bool IsUserExist(int userId)
        {
            User user = _userService.GetById(userId);
            if (user is not null)
            {
                return true;
            }
            return false;
        }

        private bool IsShoppingListNameAvaibleToAddOrUpdate(string shoppingListName, int userId)
        {
            var shoppingList = _shoppingListDal.Get(c => c.Name.ToLower() == shoppingListName.ToLower() && c.UserId == userId);
            if (shoppingList is not null)
            {
                return false;
            }
            return true;
        }

        
    }
}
