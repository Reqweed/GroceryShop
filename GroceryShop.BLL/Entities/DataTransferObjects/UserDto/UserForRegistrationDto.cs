using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entities.DataTransferObjects.UserDto;

public record UserForRegistrationDto
{
    [Required]
    [MaxLength(20)]
    public string UserName { get; init; }
    [Required]
    [EmailAddress]
    public string Email { get; init; }
    [RegularExpression(@"^\d{12,13}", ErrorMessage = "Invalid phone number format")]
    public string? PhoneNumber { get; init; } = null;
    [Required]
    [MinLength(4)]
    public string Password { get; init; }
}