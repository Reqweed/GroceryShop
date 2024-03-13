using System.ComponentModel.DataAnnotations;
using GroceryShop.DAL.Entities.Enums;

namespace GroceryShop.DAL.Entities.DataTransferObjects.OrderDto;

public record OrderForUpdatingDto
{
    public OrderStatus? OrderStatus { get; init; } = null;
    [MaxLength(100)]
    public string? Address { get; init; } = null;
}