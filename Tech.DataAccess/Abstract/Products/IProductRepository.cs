using Tech.Entity.Concrete.Products;

namespace Tech.DataAccess.Abstract.Products;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProducts();
}
