using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.BusinessLogic.Dtos;
using Tech.Entity.Concrete.Products;

namespace Tech.BusinessLogic.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewDto>> GetAllProduct();

        Task AddProduct(ProductAddDto productAddDto);
        Task Remove(int id);
        Task<ProductAddDto> GetProductByIdAsync(int id);

    }
}
