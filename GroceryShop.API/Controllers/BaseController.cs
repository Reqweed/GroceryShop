using System.Security.Claims;
using GroceryShop.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShop.API.Controllers;

[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class BaseController : ControllerBase
{
    protected readonly IServiceManager ServiceManager;

    public BaseController(IServiceManager serviceManager)
    {
        ServiceManager = serviceManager;
    }

     protected Guid UserId => User.Identity!.IsAuthenticated 
        ? Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) 
        : Guid.Empty;
}