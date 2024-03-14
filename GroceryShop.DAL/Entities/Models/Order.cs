using GroceryShop.DAL.Entities.Enums;

namespace GroceryShop.DAL.Entities.Models;

public class Order
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public decimal TotalPrice { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; }
}