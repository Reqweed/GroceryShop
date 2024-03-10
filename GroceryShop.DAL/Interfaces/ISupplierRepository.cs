using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Interfaces;

public interface ISupplierRepository
{
    IQueryable<Supplier> GetAll();
    Task<Supplier?> Get(Guid idSupplier, CancellationToken cancellationToken);
    Task<Supplier?> Get(string nameSupplier, CancellationToken cancellationToken);
    void Create(Supplier supplier);
    void Delete(Supplier supplier);
    void Update(Supplier supplier);
}