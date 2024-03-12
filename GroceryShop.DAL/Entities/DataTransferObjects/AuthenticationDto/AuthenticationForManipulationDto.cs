namespace GroceryShop.DAL.Entities.DataTransferObjects.AuthDto;

public record AuthenticationForManipulationDto
{
    public string Token { get; init; }
    public string RefreshToken { get; init; }
}