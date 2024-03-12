namespace GroceryShop.DAL.Entities.DataTransferObjects.OrderDto;

public record OrderDto : OrderForManipulationDto
{
    public Guid Id { get; init; } 
    public decimal TotalPrice { get; init; } 
    public Guid UserId { get; init; } 
}