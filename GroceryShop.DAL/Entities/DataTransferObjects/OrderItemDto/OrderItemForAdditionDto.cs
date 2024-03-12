namespace GroceryShop.DAL.Entities.DataTransferObjects.OrderItemDto;

public record OrderItemForAdditionDto : OrderItemForManipulationDto
{
    public Guid IdProduct { get; init; }
}