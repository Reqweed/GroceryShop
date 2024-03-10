using GroceryShop.DAL.Contexts;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly PostgresDbContext _postgresDbContext;

    public OrderRepository(PostgresDbContext postgresDbContext)
        => _postgresDbContext = postgresDbContext;

    public IQueryable<Order> GetAll()
        => _postgresDbContext.Orders;

    public Task<Order?> Get(Guid idOrder, CancellationToken cancellationToken)
        => _postgresDbContext.Orders
            .Where(order => order.Id == idOrder)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<Order?> GetWithOrderItem(Guid idOrder, CancellationToken cancellationToken)
        => _postgresDbContext.Orders
            .Where(order => order.Id == idOrder)
            .Include(order => order.OrderItems)
            .ThenInclude(orderItem => orderItem.Product)
            .FirstOrDefaultAsync(cancellationToken);

    public void Create(Order order)
        => _postgresDbContext.Orders.Add(order);

    public void Delete(Order order)
        => _postgresDbContext.Orders.Remove(order);

    public void Update(Order order)
        => _postgresDbContext.Orders.Update(order);
}