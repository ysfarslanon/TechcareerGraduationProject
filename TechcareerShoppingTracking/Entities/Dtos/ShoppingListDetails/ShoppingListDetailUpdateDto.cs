using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ShoppingListDetails
{
    public sealed class ShoppingListDetailUpdateDto
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public bool IsBought { get; set; }
    }
}
