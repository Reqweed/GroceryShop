namespace GroceryShop.BLL.Entities.DataTransferObjects.AuthenticationDto;

public record AuthenticationResponseDto
{
    public Guid Id { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string Token { get; init; }
    public string RefreshToken { get; init; }
}