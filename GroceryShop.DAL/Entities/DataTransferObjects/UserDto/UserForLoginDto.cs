using System.ComponentModel.DataAnnotations;

namespace GroceryShop.DAL.Entities.DataTransferObjects.UserDto;

public record UserForLoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; init; }
    [Required]
    [MinLength(4)]
    public string Password { get; init; }
}