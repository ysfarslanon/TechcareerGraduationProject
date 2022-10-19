using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        bool Add(User user);
        bool Delete(User user);
        bool Update(User user);
        ICollection<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        string GetUserRole(int userId);
    }
}
