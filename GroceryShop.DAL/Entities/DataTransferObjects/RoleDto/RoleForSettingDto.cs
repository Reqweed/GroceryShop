using System.ComponentModel.DataAnnotations;

namespace GroceryShop.DAL.Entities.DataTransferObjects.RoleDto;

public record RoleForSettingDto
{
    [Required]
    [MaxLength(25)]
    public string Name { get; init; }
}