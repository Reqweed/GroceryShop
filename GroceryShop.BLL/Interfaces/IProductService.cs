using GroceryShop.DAL.Entities.DataTransferObjects.ProductDto;

namespace GroceryShop.BLL.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductDto> GetAsync(Guid idProduct, CancellationToken cancellationToken);
    Task<ProductDto> GetWithCategoryAndSupplierAsync(Guid idProduct, CancellationToken cancellationToken);
    Task CreateAsync(ProductForCreatingDto productDto);
    Task DeleteAsync(Guid idProduct);
    Task UpdateAsync(Guid idProduct, ProductForUpdatingDto productDto);
}