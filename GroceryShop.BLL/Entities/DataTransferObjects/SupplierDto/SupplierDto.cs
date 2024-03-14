namespace GroceryShop.BLL.Entities.DataTransferObjects.SupplierDto;

public record SupplierDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string ContactNumber { get; init; }
}