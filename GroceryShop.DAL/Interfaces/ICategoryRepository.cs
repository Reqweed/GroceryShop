using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> GetAll();
    Task<Category?> GetAsync(Guid idCategory, CancellationToken cancellationToken = default);
    Task<Category?> GetAsync(string nameCategory, CancellationToken cancellationToken = default);
    void Create(Category category);
    void Delete(Category category);
    void Update(Category category);
}