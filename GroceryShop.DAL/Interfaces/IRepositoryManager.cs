namespace GroceryShop.DAL.Interfaces;

public interface IRepositoryManager
{
    IOrderRepository Order { get; }
    IProductRepository Product { get; }
    ICategoryRepository Category { get; }
    ISupplierRepository Supplier { get; }
    void Save();
}