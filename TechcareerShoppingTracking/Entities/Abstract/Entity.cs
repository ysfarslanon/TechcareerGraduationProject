using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public Entity()
        {

        }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}
