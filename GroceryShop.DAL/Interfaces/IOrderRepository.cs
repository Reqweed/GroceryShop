using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Interfaces;

public interface IOrderRepository
{
    IQueryable<Order> GetAll();
    Task<Order?> Get(Guid idOrder, CancellationToken cancellationToken);
    Task<Order?> GetWithOrderItem(Guid idOrder, CancellationToken cancellationToken);
    void Create(Order order);
    void Delete(Order order);
    void Update(Order order);
}