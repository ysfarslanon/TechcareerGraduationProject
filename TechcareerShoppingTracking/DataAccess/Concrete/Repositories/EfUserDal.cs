using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class EfUserDal : EfRepositoryBase<User, Context>, IUserDal
    {
        public EfUserDal(Context context) : base(context)
        {
        }

        public string GetUserRole(int userId)
        {
            var claim = from u in Context.Users.Where(u => u.Id == userId)
                        join opc in Context.Roles
                        on u.RoleId equals opc.Id
                        select opc.Name;

            var a = Context.Users.Where(u => u.Id == userId).Include(i => i.Role).FirstOrDefault();

             return a.Role.Name;

        }

        
    }
}
