using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entity.DataTransferObjects.UserDto;

public record UserForRegistrationDto
{
    [Required]
    [MaxLength(20)]
    public string UserName { get; init; }
    [Required]
    [EmailAddress]
    public string Email { get; init; }
    [MaxLength(13), MinLength(13)]
    public string? PhoneNumber { get; init; } = null;
    [Required]
    [MinLength(4)]
    public string Password { get; init; }
}