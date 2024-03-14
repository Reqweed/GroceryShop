using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entity.DataTransferObjects.UserDto;

public record UserForUpdatingDto
{
    [EmailAddress]
    public string? Email { get; init; } = null;
    [MaxLength(13), MinLength(13)]
    public string? PhoneNumber { get; init; } = null;
    [Required]
    public string Password { get; init; }
    [MinLength(4)]
    public string? NewPassword { get; init; } = null;
}