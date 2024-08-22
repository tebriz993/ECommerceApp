using Tech.Entity.Concrete.Common;

namespace Tech.Entity.Concrete.Products;

public class Order:BaseEntity
{
    public int Total { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = new Product();
}
