using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.BLL.Entity.DataTransferObjects.ProductDto;

public record ProductDto
{
    public Guid Id { get; init; }
    public Supplier Supplier { get; init; }
    public Category Category { get; init; }
    public string Name { get; init; }
    public int StockQuantity { get; init; }
    public decimal Price { get; init; }
    public string Description { get; init; }
    public Guid SupplierId { get; init; }
    public Guid CategoryId { get; init; }
    public PageInfo.PageInfo PageInfo { get; set; }
}