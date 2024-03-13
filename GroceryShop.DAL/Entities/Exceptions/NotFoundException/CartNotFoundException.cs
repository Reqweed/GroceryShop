namespace GroceryShop.DAL.Entities.Exceptions.NotFoundException;

public class CartNotFoundException : NotFoundException
{
    public CartNotFoundException(Guid idUser) 
        : base($"Cart doesn't have products for user with ID ({idUser})") { }
    public CartNotFoundException(Guid idUser, Guid idProduct) 
        : base($"Cart doesn't have product with ID ({idProduct}) for user with ID ({idUser})") { }
}