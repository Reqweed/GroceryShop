namespace GroceryShop.DAL.Entities.Exceptions.BadRequestException;

public class RefreshTokenBadRequestException : BadRequestException
{
    public RefreshTokenBadRequestException() : base("Invalid refresh token") { }
}