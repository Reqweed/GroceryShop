using Microsoft.AspNetCore.Identity;

namespace GroceryShop.DAL.Entities.Models;

public class User : IdentityUser<Guid>
{
    public ICollection<Order> Orders { get; set; }
}