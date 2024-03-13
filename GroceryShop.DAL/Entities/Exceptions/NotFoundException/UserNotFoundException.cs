namespace GroceryShop.DAL.Entities.Exceptions.NotFoundException;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException() : base("Users not found.") { }
    public UserNotFoundException(Guid idUser) : base($"User with ID ({idUser}) not found.") { }
    public UserNotFoundException(string email) : base($"User with email ({email}) already exists.") { }
}