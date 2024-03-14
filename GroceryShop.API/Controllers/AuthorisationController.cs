using GroceryShop.BLL.Entities.DataTransferObjects.RoleDto;
using GroceryShop.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShop.API.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/roles")]
public class AuthorisationController : BaseController
{
    public AuthorisationController(IServiceManager serviceManager) : base(serviceManager) { }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var roles = await ServiceManager.Authorisation.GetAllAsync(cancellationToken);

        return Ok(roles);
    }
    
    [HttpGet("{idUser:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid idUser, CancellationToken cancellationToken)
    {
        var role = await ServiceManager.Authorisation.GetAsync(idUser);

        return Ok(role);
    }
    
    [HttpDelete("{idRole:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid idRole, CancellationToken cancellationToken)
    {
        await ServiceManager.Authorisation.DeleteAsync(idRole);

        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoleForCreatingDto roleDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Authorisation.CreateAsync(roleDto);

        return CreatedAtAction(nameof(Create), null);
    }
    
    [HttpPut("{idUser:guid}")]
    public async Task<IActionResult> Set([FromRoute] Guid idUser, [FromBody] RoleForSettingDto roleDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Authorisation.SetAsync(idUser, roleDto);

        return Ok();
    }
}