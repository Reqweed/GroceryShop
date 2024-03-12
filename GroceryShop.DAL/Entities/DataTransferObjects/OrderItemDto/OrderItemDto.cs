namespace GroceryShop.DAL.Entities.DataTransferObjects.OrderItemDto;

public record OrderItemDto : OrderItemForManipulationDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}