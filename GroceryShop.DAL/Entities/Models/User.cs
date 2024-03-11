using Microsoft.AspNetCore.Identity;

namespace GroceryShop.DAL.Entities.Models;

public class User : IdentityUser<Guid>
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public ICollection<Order> Orders { get; set; }
}