using GroceryShop.DAL.Contexts;
using GroceryShop.DAL.Entities.Models;
using GroceryShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly PostgresDbContext _postgresDbContext;

    public CategoryRepository(PostgresDbContext postgresDbContext)
        => _postgresDbContext = postgresDbContext;
    
    public IQueryable<Category> GetAll()
        => _postgresDbContext.Categories;

    public async Task<Category?> Get(Guid idCategory, CancellationToken cancellationToken)
        => await _postgresDbContext.Categories
            .Where(category => category.Id == idCategory)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Category?> Get(string nameCategory, CancellationToken cancellationToken)
        => await _postgresDbContext.Categories
            .Where(category => category.Name == nameCategory)
            .FirstOrDefaultAsync(cancellationToken);

    public void Create(Category category)
        => _postgresDbContext.Categories.Add(category);

    public void Delete(Category category)
        => _postgresDbContext.Categories.Remove(category);

    public void Update(Category category)
        => _postgresDbContext.Categories.Update(category);
}