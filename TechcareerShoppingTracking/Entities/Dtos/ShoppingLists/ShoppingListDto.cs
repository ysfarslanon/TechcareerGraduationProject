using Entities.Dtos.ShoppingListDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ShoppingLists
{
    public sealed class ShoppingListDto
    {
        public int ShoppingListId { get; set; }
        public string ShoppingListName { get; set; }
        public string UserFullName { get; set; }
        public bool IsShopping { get; set; }
        public List<ShoppingListDetailDto>? Details { get; set; }
    }
}
