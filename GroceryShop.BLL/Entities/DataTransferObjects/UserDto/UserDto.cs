namespace GroceryShop.BLL.Entities.DataTransferObjects.UserDto;

public record UserDto 
{
    public Guid Id { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
}