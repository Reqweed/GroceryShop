namespace GroceryShop.DAL.Entities.Exceptions.NotFoundException;

public class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message) { }
}