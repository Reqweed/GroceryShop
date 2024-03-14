using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entity.DataTransferObjects.CategoryDto;

public record CategoryForUpdatingDto
{
    [Required]
    public string Name { get; init; }
}