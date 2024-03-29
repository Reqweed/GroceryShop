using GroceryShop.BLL.Entities.DataTransferObjects.ParametersDto;
using GroceryShop.BLL.Entities.DataTransferObjects.ProductDto;
using GroceryShop.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShop.API.Controllers;

[Route("api/[controller]")]
public class ProductsController : BaseController
{
    public ProductsController(IServiceManager serviceManager) : base(serviceManager) { }
    
    [AllowAnonymous]
    [HttpPost("catalog")]
    public async Task<IActionResult> GetAll([FromBody] GetAllParametersDto parameters, CancellationToken cancellationToken)
    {
        var products = await ServiceManager.Product.GetAllAsync(parameters, cancellationToken);
    
        return Ok(products);
    }
    
    [AllowAnonymous]
    [HttpGet("{idProduct:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid idProduct, CancellationToken cancellationToken)
    {
        var product = await ServiceManager.Product.GetAsync(idProduct, cancellationToken);

        return Ok(product);
    }
    
    [AllowAnonymous]
    [HttpGet("{idProduct:guid}/info")]
    public async Task<IActionResult> GetWithInfo([FromRoute] Guid idProduct, CancellationToken cancellationToken)
    {
        var product = await ServiceManager.Product.GetWithCategoryAndSupplierAsync(idProduct, cancellationToken);

        return Ok(product);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductForCreatingDto productDto,CancellationToken cancellationToken)
    {
        await ServiceManager.Product.CreateAsync(productDto);

        return CreatedAtAction(nameof(Create), null);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{idProduct:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid idProduct, CancellationToken cancellationToken)
    {
        await ServiceManager.Product.DeleteAsync(idProduct);

        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPut("{idProduct:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid idProduct, ProductForUpdatingDto productDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Product.UpdateAsync(idProduct, productDto);

        return Ok();
    }
}