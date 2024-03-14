namespace GroceryShop.DAL.Entities.Exceptions.NotFoundException;

public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException() : base("Categories not found.") { }
    public CategoryNotFoundException(Guid idCategory) : base($"Category with ID ({idCategory}) not found.") { }
}