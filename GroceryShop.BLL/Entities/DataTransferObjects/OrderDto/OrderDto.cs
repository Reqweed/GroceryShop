namespace GroceryShop.BLL.Entities.DataTransferObjects.OrderDto;

public record OrderDto
{
    public Guid Id { get; init; } 
    public decimal TotalPrice { get; init; } 
    public Guid UserId { get; init; } 
    public string Address { get; init; } 
}