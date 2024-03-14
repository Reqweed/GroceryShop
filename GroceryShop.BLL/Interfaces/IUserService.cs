using GroceryShop.BLL.Entities.DataTransferObjects.UserDto;

namespace GroceryShop.BLL.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<UserDto> GetAsync(Guid idUser);
    Task DeleteAsync(Guid idUser);
    Task UpdateAsync(Guid idUser, UserForUpdatingDto userDto);
}