namespace GroceryShop.DAL.Entities.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    
    public Guid? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; }
}