namespace GroceryShop.DAL.Entities.Exceptions.BadRequestException;

public class BadRequestException : Exception
{
    public BadRequestException() : base("Invalid operation") {}
    protected BadRequestException(string message) : base(message) {}
}