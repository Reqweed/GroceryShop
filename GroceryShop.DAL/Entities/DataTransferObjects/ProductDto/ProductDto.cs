using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.DAL.Entities.DataTransferObjects.ProductDto;

public record ProductDto : ProductForManipulationDto
{
    public Guid Id { get; init; }
    public Supplier Supplier { get; init; }
    public Category Category { get; init; }
}