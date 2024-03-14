using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entity.DataTransferObjects.SupplierDto;

public record SupplierForUpdatingDto
{
    [MaxLength(25)]
    public string? Name { get; init; } = null;
    [MaxLength(13), MinLength(13)]
    public string? ContactNumber { get; init; } = null;
}