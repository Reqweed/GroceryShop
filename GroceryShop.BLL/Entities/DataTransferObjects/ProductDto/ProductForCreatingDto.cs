using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entities.DataTransferObjects.ProductDto;

public record ProductForCreatingDto
{
    [Required]
    [MaxLength(25)]
    public string Name { get; init; }
    [Required]
    public int StockQuantity { get; init; }
    [Required]
    public decimal Price { get; init; }
    [MaxLength(100)] 
    public string? Description { get; init; } = null;
    [Required]
    public Guid SupplierId { get; init; }
    [Required]
    public Guid CategoryId { get; init; }
}