using GroceryShop.DAL.Contexts;
using GroceryShop.DAL.Interfaces;

namespace GroceryShop.DAL.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<ISupplierRepository> _supplierRepository;

    public RepositoryManager(PostgresDbContext postgresDbContext)
    {
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(postgresDbContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(postgresDbContext));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(postgresDbContext));
        _supplierRepository = new Lazy<ISupplierRepository>(() => new SupplierRepository(postgresDbContext));
    }
    
    public IOrderRepository Order => _orderRepository.Value;
    public IProductRepository Product => _productRepository.Value;
    public ICategoryRepository Category => _categoryRepository.Value;
    public ISupplierRepository Supplier => _supplierRepository.Value;
}