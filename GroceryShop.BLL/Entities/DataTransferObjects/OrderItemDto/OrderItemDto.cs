namespace GroceryShop.BLL.Entities.DataTransferObjects.OrderItemDto;

public record OrderItemDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Quantity { get; init; }
}