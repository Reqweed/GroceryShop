namespace GroceryShop.DAL.Entities.DataTransferObjects.OrderItemDto;

public record OrderItemForDeletionDto : OrderItemForManipulationDto
{
    public Guid IdProduct { get; init; }
}