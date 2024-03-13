using System.ComponentModel.DataAnnotations;

namespace GroceryShop.DAL.Entities.DataTransferObjects.CategoryDto;

public record CategoryForUpdatingDto
{
    [Required]
    public string Name { get; init; }
}