namespace GroceryShop.DAL.Entities.DataTransferObjects.SupplierDto;

public record SupplierForManipulationDto
{
    public string Name { get; init; }
    public string ContactNumber { get; init; }
}