using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string PictureURL { get; set; }


        public Category Category { get; set; }
        public virtual ICollection<ShoppingListDetail> ShoppingListDetails { get; set; }

        public Product()
        {

        }

        public Product(int id, int categoryId, string name, string pictureURL)
        {
            Id = id;
            Name = name;
            PictureURL = pictureURL;
            CategoryId = categoryId;
        }
    }
}
