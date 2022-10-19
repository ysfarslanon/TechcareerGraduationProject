using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ShoppingListDetails
{
    public sealed class ShoppingListDetailChangeDescriptionDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
