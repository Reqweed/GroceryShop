namespace GroceryShop.DAL.Entities.DataTransferObjects.OrderDto;

public record OrderInfoDto : OrderForManipulationDto
{
    public Guid Id { get; init; } 
    public Guid UserId { get; init; } 
    public decimal TotalPrice { get; init; } 
}