namespace GroceryShop.DAL.Entities.DataTransferObjects.RoleDto;

public record RoleDto : RoleForManipulationDto
{
    public Guid Id { get; set; }
}