using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> GetAll();
    Task<Category?> Get(Guid idCategory, CancellationToken cancellationToken);
    Task<Category?> Get(string nameCategory, CancellationToken cancellationToken);
    void Create(Category category);
    void Delete(Category category);
    void Update(Category category);
}