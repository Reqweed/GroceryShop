using System.ComponentModel.DataAnnotations;

namespace GroceryShop.BLL.Entities.DataTransferObjects.UserDto;

public record UserForLoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; init; }
    [Required]
    [MinLength(4)]
    public string Password { get; init; }
}