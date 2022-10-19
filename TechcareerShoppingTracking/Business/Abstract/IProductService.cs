using Entities.Concrete;
using Entities.Dtos.Categories;
using Entities.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        bool Add(ProductAddDto productAddDto);
        bool Delete(ProductDeleteDto productDeleteDto);
        bool Update(ProductUpdateDto productUpdateDto);
        ICollection<ProductDto> GetAllWithDetail();
        ProductDto GetByIdWithDetail(int id);
        ICollection<Product> GetAll();
        Product GetById(int id);
        ICollection<ProductDto> GetAllWithDetailByCategoryId(int categoryId);

    }
}
