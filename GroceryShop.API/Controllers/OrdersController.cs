using GroceryShop.BLL.Entities.DataTransferObjects.OrderDto;
using GroceryShop.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShop.API.Controllers;

[Route("api/[controller]")]
public class OrdersController : BaseController
{
    public OrdersController(IServiceManager serviceManager) : base(serviceManager) { }
    
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var orders = await ServiceManager.Order.GetAllAsync(cancellationToken);

        return Ok(orders);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("user/{idUser:guid}")]
    public async Task<IActionResult> GetAllForUser([FromRoute] Guid idUser, CancellationToken cancellationToken)
    {
        var orders = await ServiceManager.Order.GetAllAsync(idUser);
    
        return Ok(orders);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetAllForUser(CancellationToken cancellationToken)
    {
        var orders = await ServiceManager.Order.GetAllAsync(UserId);
    
        return Ok(orders);
    }
    
    [HttpGet("{idOrder:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid idOrder, CancellationToken cancellationToken)
    {
        var order = await ServiceManager.Order.GetAsync(idOrder, cancellationToken);

        return Ok(order);
    }

    [HttpGet("{idOrder:guid}/info")]
    public async Task<IActionResult> GetWithInfo([FromRoute] Guid idOrder, CancellationToken cancellationToken)
    {
        var order = await ServiceManager.Order.GetWithOrderItemAsync(idOrder, cancellationToken);

        return Ok(order);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderForCreatingDto orderDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Order.CreateAsync(UserId, orderDto, cancellationToken);

        return CreatedAtAction(nameof(Create), null);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{idOrder:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid idOrder, CancellationToken cancellationToken)
    {
        await ServiceManager.Order.DeleteAsync(idOrder);

        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPut("{idOrder:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid idOrder, [FromBody] OrderForUpdatingDto orderDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Order.UpdateAsync(idOrder, orderDto);

        return Ok();
    }
}