using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ShoppingListDetails
{
    public sealed class ShoppingListDetailChangeIsBoughtDto
    {
        public int Id { get; set; }
        public bool IsBought { get; set; }
    }
}
