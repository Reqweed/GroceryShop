using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Interfaces;

public interface IOrderRepository
{
    IQueryable<Order> GetAll();
    Task<Order?> GetAsync(Guid idOrder, CancellationToken cancellationToken = default);
    Task<Order?> GetWithOrderItemAsync(Guid idOrder, CancellationToken cancellationToken = default);
    void Create(Order order);
    void Delete(Order order);
    void Update(Order order);
}