using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ShoppingListDetails
{
    public sealed class ShoppingListDetailAddDto
    {
        public int ShoppingListId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public bool IsBought { get; set; }
    }
}
