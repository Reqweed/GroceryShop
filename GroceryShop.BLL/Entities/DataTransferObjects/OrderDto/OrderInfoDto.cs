namespace GroceryShop.BLL.Entities.DataTransferObjects.OrderDto;

public record OrderInfoDto
{
    public Guid Id { get; init; } 
    public Guid UserId { get; init; } 
    public decimal TotalPrice { get; init; } 
    public string Address { get; init; } 
}