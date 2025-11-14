using Core.Entities;
using Core.FluentApiConfigurations;
using Microsoft.EntityFrameworkCore;

public class OnlineShopDbContext:DbContext
{
    public OnlineShopDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       // base.OnModelCreating(modelBuilder);
       modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
       modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}