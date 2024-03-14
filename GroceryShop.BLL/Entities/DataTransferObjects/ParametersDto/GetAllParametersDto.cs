using System.ComponentModel.DataAnnotations;
using GroceryShop.BLL.Entities.Enums;

namespace GroceryShop.BLL.Entities.DataTransferObjects.ParametersDto;

public class GetAllParametersDto
{
    public TypeProductSorting Sorting { get; set; } = TypeProductSorting.No;
    public string Name { get; set; } = string.Empty;
    [Required]
    public PageInfo.PageInfo PageInfo { get; set; }
}