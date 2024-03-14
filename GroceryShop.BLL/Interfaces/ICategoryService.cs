using GroceryShop.BLL.Entity.DataTransferObjects.CategoryDto;

namespace GroceryShop.BLL.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<CategoryDto> GetAsync(Guid idCategory, CancellationToken cancellationToken);
    Task CreateAsync(CategoryForCreatingDto categoryDto);
    Task DeleteAsync(Guid idCategory,  CancellationToken cancellationToken);
    Task UpdateAsync(Guid idCategory, CategoryForUpdatingDto categoryDto);
}