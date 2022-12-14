using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Role()
        {

        }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
