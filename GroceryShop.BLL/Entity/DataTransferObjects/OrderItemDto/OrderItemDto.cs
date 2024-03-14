namespace GroceryShop.BLL.Entity.DataTransferObjects.OrderItemDto;

public record OrderItemDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Quantity { get; init; }
}