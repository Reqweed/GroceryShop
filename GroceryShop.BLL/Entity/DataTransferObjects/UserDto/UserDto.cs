namespace GroceryShop.BLL.Entity.DataTransferObjects.UserDto;

public record UserDto 
{
    public Guid Id { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
}