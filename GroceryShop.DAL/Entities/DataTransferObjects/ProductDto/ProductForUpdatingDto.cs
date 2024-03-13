using System.ComponentModel.DataAnnotations;

namespace GroceryShop.DAL.Entities.DataTransferObjects.ProductDto;

public record ProductForUpdatingDto
{
    [MaxLength(25)]
    public string? Name { get; init; } = null;
    public int? StockQuantity { get; init; } = null;
    public decimal? Price { get; init; } = null;
    [MaxLength(100)]
    public string? Description { get; init; } = null;
    public Guid? SupplierId { get; init; } = null;
    public Guid? CategoryId { get; init; } = null;
}
    