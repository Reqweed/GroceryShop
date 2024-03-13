namespace GroceryShop.DAL.Entities.Exceptions.NotFoundException;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException() : base("Products not found.") { }
    public ProductNotFoundException(Guid idProduct, int quantity) : base($"There aren't enough product with an ({idProduct}), there are only {quantity}.") { }
    public ProductNotFoundException(Guid idProduct) : base($"Product with ID ({idProduct}) not found.") { }
}