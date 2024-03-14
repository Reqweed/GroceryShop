using GroceryShop.BLL.Entity.DataTransferObjects.RoleDto;

namespace GroceryShop.BLL.Auth.Interfaces;

public interface IAuthorisationService
{
    Task<IEnumerable<RoleDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<RoleDto> GetAsync(Guid idUser);
    Task DeleteAsync(Guid idRole);
    Task CreateAsync(RoleForCreatingDto roleDto);
    Task SetAsync(Guid idUser, RoleForSettingDto roleDto);
}