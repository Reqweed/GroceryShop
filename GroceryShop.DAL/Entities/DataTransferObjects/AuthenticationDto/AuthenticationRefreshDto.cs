namespace GroceryShop.DAL.Entities.DataTransferObjects.AuthenticationDto;

public record AuthenticationRefreshDto
{
    public string Token { get; init; }
    public string RefreshToken { get; init; }
}