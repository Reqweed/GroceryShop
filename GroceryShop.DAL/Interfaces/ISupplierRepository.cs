using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Interfaces;

public interface ISupplierRepository
{
    IQueryable<Supplier> GetAll();
    Task<Supplier?> GetAsync(Guid idSupplier, CancellationToken cancellationToken = default);
    void Create(Supplier supplier);
    void Delete(Supplier supplier);
    void Update(Supplier supplier);
}