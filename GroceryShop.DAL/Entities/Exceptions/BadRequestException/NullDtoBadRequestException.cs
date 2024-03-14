namespace GroceryShop.DAL.Entities.Exceptions.BadRequestException;

public class NullDtoBadRequestException : BadRequestException
{
    public NullDtoBadRequestException() : base("The DTO object cannot be null.") { }
}