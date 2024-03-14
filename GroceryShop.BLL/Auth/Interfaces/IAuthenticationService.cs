using GroceryShop.BLL.Entities.DataTransferObjects.AuthenticationDto;
using GroceryShop.BLL.Entities.DataTransferObjects.UserDto;

namespace GroceryShop.BLL.Auth.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResponseDto> RegistrationAsync(UserForRegistrationDto userDto);
    Task<AuthenticationResponseDto> LoginAsync(UserForLoginDto userDto);
    Task<AuthenticationResponseDto> UpdateTokenAsync(AuthenticationRefreshDto authenticationRefreshDto);
}