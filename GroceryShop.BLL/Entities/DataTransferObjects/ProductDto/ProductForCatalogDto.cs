using GroceryShop.BLL.Entities.DataTransferObjects.ParametersDto;

namespace GroceryShop.BLL.Entities.DataTransferObjects.ProductDto;

public class ProductForCatalogDto
{
    public IEnumerable<ProductDto> Products { get; set; }
    public GetAllParametersDto Parameters { get; set; }
}