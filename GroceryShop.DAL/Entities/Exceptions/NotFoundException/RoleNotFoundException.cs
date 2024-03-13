namespace GroceryShop.DAL.Entities.Exceptions.NotFoundException;

public class RoleNotFoundException : NotFoundException
{
    public RoleNotFoundException() : base("Roles not found.") { }
    public RoleNotFoundException(Guid idRole) : base($"Role with ID ({idRole}) not found.") { }
    public RoleNotFoundException(string nameRole) : base($"Role ({nameRole}) not found.") { }
}