namespace GroceryShop.DAL.Entities.DataTransferObjects.OrderItemDto;

public record OrderItemForManipulationDto
{
    public int Quantity { get; init; }
}