namespace GroceryShop.BLL.Entities.DataTransferObjects.RoleDto;

public record RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; init; }
}