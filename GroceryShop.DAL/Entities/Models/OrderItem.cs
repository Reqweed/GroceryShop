namespace GroceryShop.DAL.Entities.Models;

public class OrderItem
{
    public Guid Id { get; set; }
    public int Quality { get; set; }
    public decimal Price { get; set; }
    
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}