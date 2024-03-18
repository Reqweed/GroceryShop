using GroceryShop.DAL.Configurations;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Initializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GroceryShop.DAL.Contexts;

public sealed class PostgresDbContext : IdentityDbContext<User, Role, Guid>
{
    private readonly IConfiguration _configuration;

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    
    public PostgresDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetSection("PostgresSql:ConnectionString").Value);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

        modelBuilder.Entity<Category>().HasData(DataInitializer.Categories);
        modelBuilder.Entity<Supplier>().HasData(DataInitializer.Suppliers);
        modelBuilder.Entity<Product>().HasData(DataInitializer.Products);
        modelBuilder.Entity<Role>().HasData(DataInitializer.Roles);
        modelBuilder.Entity<User>().HasData(DataInitializer.Users);
        modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(DataInitializer.IdentityUserRoles);
    }
}