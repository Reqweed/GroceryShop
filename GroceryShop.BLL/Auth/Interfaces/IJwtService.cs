using System.Security.Claims;
using GroceryShop.DAL.Entities.Models;

namespace GroceryShop.BLL.Auth.Interfaces;

public interface IJwtService
{
    string CreateToken(User user);
    string CreateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}