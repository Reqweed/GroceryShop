namespace GroceryShop.BLL.Entity.DataTransferObjects.CategoryDto;

public record CategoryDto
{
    public Guid Id { get; init; } 
    public string Name { get; init; }
}