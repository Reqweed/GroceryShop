using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entity.DataTransferObjects.CategoryDto;

public record CategoryForCreatingDto
{
    [Required]
    [MaxLength(25)]
    public string Name { get; init; }
}