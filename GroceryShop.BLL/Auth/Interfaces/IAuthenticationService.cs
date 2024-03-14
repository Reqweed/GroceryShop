using GroceryShop.BLL.Entity.DataTransferObjects.AuthenticationDto;
using GroceryShop.BLL.Entity.DataTransferObjects.UserDto;

namespace GroceryShop.BLL.Auth.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResponseDto> RegistrationAsync(UserForRegistrationDto userDto);
    Task<AuthenticationResponseDto> LoginAsync(UserForLoginDto userDto);
    Task<AuthenticationResponseDto> UpdateTokenAsync(AuthenticationRefreshDto authenticationRefreshDto);
}