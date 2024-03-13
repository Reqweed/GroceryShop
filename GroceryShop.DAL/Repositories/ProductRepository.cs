using GroceryShop.DAL.Contexts;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.DAL.Repositories;

public class ProductRepository :  IProductRepository
{
    private readonly PostgresDbContext _postgresDbContext;

    public ProductRepository(PostgresDbContext postgresDbContext)
        => _postgresDbContext = postgresDbContext;

    public IQueryable<Product> GetAll()
        => _postgresDbContext.Products;

    public Task<Product?> GetAsync(Guid idProduct, CancellationToken cancellationToken = default)
        => _postgresDbContext.Products
            .FirstOrDefaultAsync(product => product.Id == idProduct, cancellationToken);

    public Task<Product?> GetWithCategoryAndSupplierAsync(Guid idProduct, CancellationToken cancellationToken = default)
        => _postgresDbContext.Products
            .Where(product => product.Id == idProduct)
            .Include(product => product.Category)
            .Include(product => product.Supplier)
            .FirstOrDefaultAsync(cancellationToken);

    public void Create(Product product)
        => _postgresDbContext.Products.Add(product);

    public void Delete(Product product)
        => _postgresDbContext.Products.Remove(product);
    
    public void Update(Product product)
        => _postgresDbContext.Products.Update(product);
}