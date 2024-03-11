using GroceryShop.DAL.Contexts;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.DAL.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly PostgresDbContext _postgresDbContext;

    public SupplierRepository(PostgresDbContext postgresDbContext)
        => _postgresDbContext = postgresDbContext;

    public IQueryable<Supplier> GetAll()
        => _postgresDbContext.Suppliers;

    public async Task<Supplier?> GetAsync(Guid idSupplier, CancellationToken cancellationToken = default)
        => await _postgresDbContext.Suppliers
            .Where(supplier => supplier.Id == idSupplier)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Supplier?> GetAsync(string nameSupplier, CancellationToken cancellationToken = default)
        => await _postgresDbContext.Suppliers
            .Where(supplier => supplier.Name == nameSupplier)
            .FirstOrDefaultAsync(cancellationToken);

    public void Create(Supplier supplier)
        => _postgresDbContext.Suppliers.Add(supplier);

    public void Delete(Supplier supplier)
        => _postgresDbContext.Suppliers.Remove(supplier);

    public void Update(Supplier supplier)
        => _postgresDbContext.Suppliers.Update(supplier);
}