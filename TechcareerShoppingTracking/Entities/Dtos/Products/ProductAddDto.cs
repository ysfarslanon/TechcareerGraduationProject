using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Products
{
    public sealed class ProductAddDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
    }
}
