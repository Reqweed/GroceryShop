using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entity.DataTransferObjects.SupplierDto;

public record SupplierForCreatingDto
{
    [Required]
    [MaxLength(25)]
    public string Name { get; init; } 
    [Required]
    [MaxLength(13), MinLength(13)]
    public string ContactNumber { get; init; }
}