using GroceryShop.BLL.Entities.DataTransferObjects.AuthenticationDto;
using GroceryShop.BLL.Entities.DataTransferObjects.UserDto;
using GroceryShop.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShop.API.Controllers;

[Route("api")]
public class AuthenticationController : BaseController
{
    public AuthenticationController(IServiceManager serviceManager) : base(serviceManager) { }
    
    [AllowAnonymous]
    [HttpPost("registration")]
    public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userDto, CancellationToken cancellationToken)
    {
        var response = await ServiceManager.Authentication.RegistrationAsync(userDto);

        return CreatedAtAction(nameof(Register), null);
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userDto, CancellationToken cancellationToken)
    {
        var response = await ServiceManager.Authentication.LoginAsync(userDto);

        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> UpdateToken([FromBody] AuthenticationRefreshDto authenticationRefreshDto, CancellationToken cancellationToken)
    {
        var response = await ServiceManager.Authentication.UpdateTokenAsync(authenticationRefreshDto);
        
        return Ok(response);
    }
}