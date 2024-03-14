using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entities.DataTransferObjects.RoleDto;

public record RoleForCreatingDto
{
    [Required]
    [MaxLength(25)]
    public string Name { get; init; }
}