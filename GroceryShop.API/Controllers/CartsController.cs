using GroceryShop.BLL.Entity.DataTransferObjects.OrderItemDto;
using GroceryShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShop.API.Controllers;


[Route("api/[controller]")]
public class CartsController : BaseController
{
    public CartsController(IServiceManager serviceManager) : base(serviceManager) { }
    
    [HttpGet]
    public async Task<IActionResult> GetCart(CancellationToken cancellationToken)
    {
        var cart = await ServiceManager.Cart.GetCartAsync(UserId, cancellationToken);

        return Ok(cart);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddToCart([FromBody] OrderItemForAdditionDto orderItemDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Cart.AddAsync(UserId, orderItemDto, cancellationToken);

        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteInCart([FromBody] OrderItemForDeletionDto orderItemDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Cart.RemoveAsync(UserId, orderItemDto, cancellationToken);

        return Ok();
    }
}