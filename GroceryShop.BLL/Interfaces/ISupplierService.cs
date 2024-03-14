using GroceryShop.BLL.Entities.DataTransferObjects.SupplierDto;

namespace GroceryShop.BLL.Interfaces;

public interface ISupplierService
{
    Task<IEnumerable<SupplierDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<SupplierDto> GetAsync(Guid idSupplier, CancellationToken cancellationToken);
    Task CreateAsync(SupplierForCreatingDto supplierDto);
    Task DeleteAsync(Guid idSupplier, CancellationToken cancellationToken);
    Task UpdateAsync(Guid idSupplier, SupplierForUpdatingDto supplierDto);
}