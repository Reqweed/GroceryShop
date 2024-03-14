using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entity.DataTransferObjects.OrderDto;

public record OrderForCreatingDto
{
    [Required]
    [MaxLength(100)]
    public string Address { get; init; } 
}