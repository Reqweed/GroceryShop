using System.ComponentModel.DataAnnotations;
using GroceryShop.DAL.Entities.Enums;

namespace GroceryShop.BLL.Entity.DataTransferObjects.OrderDto;

public record OrderForUpdatingDto
{
    public OrderStatus? OrderStatus { get; init; } = null;
    [MaxLength(100)]
    public string? Address { get; init; } = null;
}