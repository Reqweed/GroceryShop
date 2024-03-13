using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Interfaces;

public interface IProductRepository
{
    IQueryable<Product> GetAll();
    Task<Product?> GetAsync(Guid idProduct, CancellationToken cancellationToken = default);
    Task<Product?> GetWithCategoryAndSupplierAsync(Guid idProduct, CancellationToken cancellationToken = default);
    void Create(Product product);
    void Delete(Product product);
    void Update(Product product);
}