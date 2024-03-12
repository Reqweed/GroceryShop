namespace GroceryShop.DAL.Entities.DataTransferObjects.UserDto;

public record UserForLoginDto
{
    public string Email { get; init; }
    public string Password { get; init; }
}