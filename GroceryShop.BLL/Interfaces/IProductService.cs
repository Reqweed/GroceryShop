using GroceryShop.BLL.Entities.DataTransferObjects.ParametersDto;
using GroceryShop.BLL.Entities.DataTransferObjects.ProductDto;

namespace GroceryShop.BLL.Interfaces;

public interface IProductService
{
    Task<ProductForCatalogDto> GetAllAsync(GetAllParametersDto parameters, CancellationToken cancellationToken);
    Task<ProductDto> GetAsync(Guid idProduct, CancellationToken cancellationToken);
    Task<ProductDto> GetWithCategoryAndSupplierAsync(Guid idProduct, CancellationToken cancellationToken);
    Task CreateAsync(ProductForCreatingDto productDto);
    Task DeleteAsync(Guid idProduct);
    Task UpdateAsync(Guid idProduct, ProductForUpdatingDto productDto);
}