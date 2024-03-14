namespace GroceryShop.BLL.Entities.DataTransferObjects.CategoryDto;

public record CategoryDto
{
    public Guid Id { get; init; } 
    public string Name { get; init; }
}