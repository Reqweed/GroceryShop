using System.ComponentModel.DataAnnotations;

namespace GroceryShop.DAL.Entities.DataTransferObjects.CategoryDto;

public record CategoryForCreatingDto
{
    [Required]
    [MaxLength(25)]
    public string Name { get; init; }
}