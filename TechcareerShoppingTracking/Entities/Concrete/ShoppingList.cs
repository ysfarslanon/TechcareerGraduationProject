using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ShoppingList : Entity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsShopping { get; set; }
        public DateTime CreatedDate { get; }


        public User User { get; set; }
        public virtual ICollection<ShoppingListDetail> ShoppingListDetails { get; set; }

        public ShoppingList()
        {
            CreatedDate = DateTime.Now;
        }

        public ShoppingList(int id, int userId, string name, bool isShopping = false) : this()
        {
            Id = id;
            UserId = userId;
            Name = name;
            IsShopping = isShopping;
        }
    }
}
