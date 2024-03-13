namespace GroceryShop.DAL.Entities.Exceptions.BadRequestException;

public class ValidationBadRequestException : BadRequestException
{
    public ValidationBadRequestException(string message): base(message) { }
}