using GroceryShop.DAL.Contexts;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.DAL.Repositories;

public class CartRepository : ICartRepository
{
    private readonly PostgresDbContext _postgresDbContext;

    public CartRepository(PostgresDbContext postgresDbContext)
    {
        _postgresDbContext = postgresDbContext;
    }

    public IQueryable<OrderItem> GetAll(Guid idUser)
        => _postgresDbContext.OrderItems.Where(orderItem => orderItem.UserId == idUser 
                                                            && orderItem.OrderId == default);

    public async Task<OrderItem?> GetAsync(Guid idUser, Guid idProduct, CancellationToken cancellationToken = default)
        => await _postgresDbContext.OrderItems
            .FirstOrDefaultAsync(orderItem => orderItem.ProductId == idProduct 
                                              && orderItem.UserId == idUser && orderItem.OrderId == default, 
                cancellationToken: cancellationToken);

    public void Create(OrderItem orderItem)
        => _postgresDbContext.OrderItems.Add(orderItem);

    public void Delete(OrderItem orderItem)
        => _postgresDbContext.OrderItems.Remove(orderItem);

    public void Update(OrderItem orderItem)
        => _postgresDbContext.OrderItems.Update(orderItem);
}