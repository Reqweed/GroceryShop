namespace GroceryShop.BLL.Entity.DataTransferObjects.RoleDto;

public record RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; init; }
}