using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ShoppingListDetails
{
    public sealed class ShoppingListDetailDto
    {
        public int ShoppingListDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPictureURL { get; set; }
        public string ListName { get; set; }
        public string? Description { get; set; }
        public bool IsBought { get; set; }

    }
}