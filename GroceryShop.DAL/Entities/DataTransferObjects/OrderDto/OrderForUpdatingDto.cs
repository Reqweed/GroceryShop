using GroceryShop.DAL.Entities.Enums;

namespace GroceryShop.DAL.Entities.DataTransferObjects.OrderDto;

public record OrderForUpdatingDto : OrderForManipulationDto
{
    public OrderStatus OrderStatus { get; init; } 
}