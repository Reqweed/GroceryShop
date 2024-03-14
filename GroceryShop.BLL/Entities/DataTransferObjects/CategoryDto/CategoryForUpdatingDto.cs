using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entities.DataTransferObjects.CategoryDto;

public record CategoryForUpdatingDto
{
    [Required]
    public string Name { get; init; }
}