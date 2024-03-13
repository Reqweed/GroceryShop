using GroceryShop.BLL.Interfaces;
using GroceryShop.DAL.Entities.DataTransferObjects.CategoryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShop.API.Controllers;

[Route("api/[controller]")]
public class CategoriesController : BaseController
{
    public CategoriesController(IServiceManager serviceManager) : base(serviceManager) { }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var categories = await ServiceManager.Category.GetAllAsync(cancellationToken);

        return Ok(categories);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryForCreatingDto categoryDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Category.CreateAsync(categoryDto);

        return CreatedAtAction(nameof(Create), null);
    }
    
    [AllowAnonymous]
    [HttpGet("{idCategory:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid idCategory, CancellationToken cancellationToken)
    {
        var category = await ServiceManager.Category.GetAsync(idCategory, cancellationToken);

        return Ok(category);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{idCategory:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid idCategory, CancellationToken cancellationToken)
    {
        await ServiceManager.Category.DeleteAsync(idCategory, cancellationToken);

        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPut("{idCategory:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid idCategory, CategoryForUpdatingDto categoryDto, CancellationToken cancellationToken)
    {
        await ServiceManager.Category.UpdateAsync(idCategory, categoryDto);

        return Ok();
    }
}