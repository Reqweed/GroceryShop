namespace GroceryShop.DAL.Entities.Models;

public class Supplier
{
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public string ContactNumber { get; set; }
    
    public ICollection<Product> Products { get; set; }
}