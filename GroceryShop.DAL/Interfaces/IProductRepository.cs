using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Interfaces;

public interface IProductRepository
{
    IQueryable<Product> GetAll();
    Task<Product?> Get(Guid idProduct, CancellationToken cancellationToken);
    Task<Product?> GetWithCategoryAndSupplier(Guid idProduct, CancellationToken cancellationToken);
    Task<Product?> Get(string nameProduct, CancellationToken cancellationToken);
    void Create(Product product);
    void Delete(Product product);
    void Update(Product product);
}