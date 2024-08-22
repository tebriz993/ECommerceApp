using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tech.Entity.Concrete.Accounts;
using Tech.Entity.Concrete.Products;

namespace Tech.DataAccess.EntityFrameworks.Contexts;

public class TechContext : DbContext
{

    public TechContext(DbContextOptions<TechContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Category>()
            .HasData(
                new Category { Id = 1, Name = "Electronic", Description = "TV, Computer and Etc" },
                new Category { Id = 2, Name = "Food", Description = "Apple, Bubble Comb , etc" }
            );

        modelBuilder.Entity<Role>()
           .HasData(
               new Role { Id = 1, RoleName = "Admin" },
               new Role { Id = 2, RoleName = "Customer" }
           );
    }
}
