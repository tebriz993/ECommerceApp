using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech.DataAccess.EntityFrameworks.Configurations.Common;
using Tech.Entity.Concrete.Products;

namespace Tech.DataAccess.EntityFrameworks.Configurations.Products;

public class OrderConfig:BaseConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Total).IsRequired();
    }
}
