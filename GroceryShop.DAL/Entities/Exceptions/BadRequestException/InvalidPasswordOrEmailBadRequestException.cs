namespace GroceryShop.DAL.Entities.Exceptions.BadRequestException;

public class InvalidPasswordOrEmailBadRequestException :  BadRequestException
{
    public InvalidPasswordOrEmailBadRequestException() : base("Invalid email or password") { }
}