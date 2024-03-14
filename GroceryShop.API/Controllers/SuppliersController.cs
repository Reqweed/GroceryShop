using GroceryShop.BLL.Entity.DataTransferObjects.SupplierDto;
using GroceryShop.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShop.API.Controllers;

[Route("api/[controller]")]
public class SuppliersController : BaseController
{
    public SuppliersController(IServiceManager serviceManager) : base(serviceManager) { }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var suppliers = await ServiceManager.Supplier.GetAllAsync(cancellationToken);

        return Ok(suppliers);
    }
    
    [AllowAnonymous]
    [HttpGet("{idSupplier:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid idSupplier, CancellationToken cancellationToken)
    {
        var supplier = await ServiceManager.Supplier.GetAsync(idSupplier, cancellationToken);

        return Ok(supplier);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SupplierForCreatingDto supplierDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Supplier.CreateAsync(supplierDto);

        return CreatedAtAction(nameof(Create), null);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{idSupplier:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid idSupplier, CancellationToken cancellationToken)
    {
        await ServiceManager.Supplier.DeleteAsync(idSupplier, cancellationToken);

        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPut("{idSupplier:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid idSupplier, [FromBody] SupplierForUpdatingDto supplierDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Supplier.UpdateAsync(idSupplier, supplierDto);

        return Ok();
    }
}