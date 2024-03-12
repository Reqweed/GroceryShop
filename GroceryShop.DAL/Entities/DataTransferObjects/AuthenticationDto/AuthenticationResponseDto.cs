namespace GroceryShop.DAL.Entities.DataTransferObjects.AuthDto;

public record AuthenticationResponseDto : AuthenticationForManipulationDto
{
    public Guid Id { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
}