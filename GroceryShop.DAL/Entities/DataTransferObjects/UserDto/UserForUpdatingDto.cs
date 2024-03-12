namespace GroceryShop.DAL.Entities.DataTransferObjects.UserDto;

public record UserForUpdatingDto 
{
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string Password { get; init; }
    public string? NewPassword { get; init; }
}