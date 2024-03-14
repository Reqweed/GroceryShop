using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entities.DataTransferObjects.OrderDto;

public record OrderForCreatingDto
{
    [Required]
    [MaxLength(100)]
    public string Address { get; init; } 
}