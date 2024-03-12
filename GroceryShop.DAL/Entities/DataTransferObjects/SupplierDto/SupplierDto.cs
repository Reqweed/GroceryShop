namespace GroceryShop.DAL.Entities.DataTransferObjects.SupplierDto;

public record SupplierDto : SupplierForManipulationDto
{
    public Guid Id { get; init; }
}