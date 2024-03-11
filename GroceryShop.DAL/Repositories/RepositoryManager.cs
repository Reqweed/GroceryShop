using GroceryShop.DAL.Contexts;
using GroceryShop.DAL.Interfaces;

namespace GroceryShop.DAL.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<ISupplierRepository> _supplierRepository;
    private readonly PostgresDbContext _postgresDbContext;

    public RepositoryManager(PostgresDbContext postgresDbContext)
    {
        _postgresDbContext = postgresDbContext;
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_postgresDbContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_postgresDbContext));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_postgresDbContext));
        _supplierRepository = new Lazy<ISupplierRepository>(() => new SupplierRepository(_postgresDbContext));
    }
    
    public IOrderRepository Order => _orderRepository.Value;
    public IProductRepository Product => _productRepository.Value;
    public ICategoryRepository Category => _categoryRepository.Value;
    public ISupplierRepository Supplier => _supplierRepository.Value;
    
    public void Save()
    {
        _postgresDbContext.SaveChanges();
    }
}