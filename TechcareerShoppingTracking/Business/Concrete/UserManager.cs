using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;


        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;

        }
        public bool Add(User user)
        {
            if (!isEmailAvaibleToAddOrUpdate(user.Email)) return false;

            _userDal.Add(user);
            return true;
        }

        public bool Delete(User user)
        {
            if (!isUserExist(user.Id)) return false;

            _userDal.Delete(user);
            return true;
        }

        public ICollection<User> GetAll()
        {
            return new List<User>(_userDal.GetAll());
        }

        public User GetById(int id)
        {
            if (!isUserExist(id)) return null;

            return _userDal.Get(user => user.Id == id);
        }

        public bool Update(User user)
        {
            if (!isUserExist(user.Id)) return false;
            if (isEmailAvaibleToAddOrUpdate(user.Email)) return false;

            _userDal.Update(user);
            return true;
        }

        public User GetByEmail(string email)
        {
            var result = _userDal.Get(user => user.Email == email);
            if (result is null) return null;

            return result;
        }

        public string GetUserRole(int userId)
        {
            return _userDal.GetUserRole(userId);
        }

        // BUSINESS RULES

        private bool isEmailAvaibleToAddOrUpdate(string email)
        {
            var user = _userDal.Get(u => u.Email == email);

            if (user is not null) return false;

            return true;
        }

        private bool isUserExist(int userId)
        {
            var resultUser = _userDal.Get(u => u.Id == userId);

            if (resultUser is not null) return true;

            return false;
        }

    }
}
