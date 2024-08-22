using Tech.DataAccess.Abstract.Products;
using Tech.DataAccess.Concrete.EntityFrameworkRepositories.Commons;
using Tech.DataAccess.EntityFrameworks.Contexts;
using Tech.Entity.Concrete.Products;

namespace Tech.DataAccess.Concrete.EntityFrameworkRepositories.Products;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(TechContext dbContext) : base(dbContext)
    {
    }
}
