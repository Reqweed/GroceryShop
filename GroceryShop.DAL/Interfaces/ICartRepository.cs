using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Interfaces;

public interface ICartRepository
{
    IQueryable<OrderItem> GetAll(Guid idUser);
    Task<OrderItem?> GetAsync(Guid idUser, Guid idProduct, CancellationToken cancellationToken = default);
    void Create(OrderItem orderItem);
    void Delete(OrderItem orderItem);
    void Update(OrderItem orderItem);
}