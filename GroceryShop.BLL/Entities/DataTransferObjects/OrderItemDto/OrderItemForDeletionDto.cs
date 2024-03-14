using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entities.DataTransferObjects.OrderItemDto;

public record OrderItemForDeletionDto
{
    [Required]
    public Guid IdProduct { get; init; }
    [Required]
    public int Quantity { get; init; }
}