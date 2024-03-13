using System.ComponentModel.DataAnnotations;

namespace GroceryShop.DAL.Entities.DataTransferObjects.OrderItemDto;

public record OrderItemForDeletionDto
{
    [Required]
    public Guid IdProduct { get; init; }
    [Required]
    public int Quantity { get; init; }
}