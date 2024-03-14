using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entities.DataTransferObjects.UserDto;

public record UserForUpdatingDto
{
    [EmailAddress]
    public string? Email { get; init; } = null;
    [RegularExpression(@"^\d{12,13}", ErrorMessage = "Invalid phone number format")]
    public string? PhoneNumber { get; init; } = null;
    [Required]
    public string Password { get; init; }
    [MinLength(4)]
    public string? NewPassword { get; init; } = null;
}