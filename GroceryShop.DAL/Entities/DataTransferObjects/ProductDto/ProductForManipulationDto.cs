namespace GroceryShop.DAL.Entities.DataTransferObjects.ProductDto;

public record ProductForManipulationDto
{
    public string Name { get; init; }
    public int StockQuantity { get; init; }
    public decimal Price { get; init; }
    public string Description { get; init; }
    public Guid SupplierId { get; init; }
    public Guid CategoryId { get; init; }
}