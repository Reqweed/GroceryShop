namespace GroceryShop.DAL.Entities.Exceptions.NotFoundException;

public class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException() : base("Orders not found.") { }
    public OrderNotFoundException(Guid idOrder) : base($"Order with ID ({idOrder}) not found.") { }
}