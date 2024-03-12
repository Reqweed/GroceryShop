namespace GroceryShop.DAL.Entities.DataTransferObjects.UserDto;

public record UserForRegistrationDto
{
    public string UserName { get; init; }
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
    public string Password { get; init; }
}