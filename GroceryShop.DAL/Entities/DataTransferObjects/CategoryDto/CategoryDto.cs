namespace GroceryShop.DAL.Entities.DataTransferObjects.CategoryDto;

public record CategoryDto : CategoryForManipulationDto
{
    public Guid Id { get; init; } 
}