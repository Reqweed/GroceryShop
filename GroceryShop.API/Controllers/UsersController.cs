using GroceryShop.BLL.Entities.DataTransferObjects.UserDto;
using GroceryShop.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShop.API.Controllers;

[Route("api/[controller]")]
public class UsersController : BaseController
{
    public UsersController(IServiceManager serviceManager) : base(serviceManager) { }
    
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await ServiceManager.User.GetAllAsync(cancellationToken);

        return Ok(users);
    }
    
    [HttpGet("info")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var user = await ServiceManager.User.GetAsync(UserId);

        return Ok(user);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("{idUser:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid idUser, CancellationToken cancellationToken)
    {
        var user = await ServiceManager.User.GetAsync(idUser);

        return Ok(user);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(CancellationToken cancellationToken)
    {
        await ServiceManager.User.DeleteAsync(UserId);

        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{idUser:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid idUser, CancellationToken cancellationToken)
    {
        await ServiceManager.User.DeleteAsync(idUser);

        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserForUpdatingDto userDto, CancellationToken cancellationToken)
    {
        await ServiceManager.User.UpdateAsync(UserId, userDto);

        return Ok();
    }
}