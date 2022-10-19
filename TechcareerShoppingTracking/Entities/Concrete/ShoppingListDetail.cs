using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ShoppingListDetail : Entity
    {
        public int ShoppingListId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public bool IsBought { get; set; }

        public virtual ShoppingList ShoppingList { get; set; }
        public virtual Product Product { get; set; }

        public ShoppingListDetail()
        {

        }

        public ShoppingListDetail(int id, int shoppingListId, int productId, string? description = null, bool isBought = false)
        {
            Id = id;
            ShoppingListId = shoppingListId;
            ProductId = productId;
            Description = description;
            IsBought = isBought;
        }
    }
}
