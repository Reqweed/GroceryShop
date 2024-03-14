using AutoMapper;
using GroceryShop.BLL.Auth.Interfaces;
using GroceryShop.BLL.Entity.DataTransferObjects.RoleDto;
using GroceryShop.DAL.Entities.Exceptions.BadRequestException;
using GroceryShop.DAL.Entities.Exceptions.NotFoundException;
using GroceryShop.DAL.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.BLL.Auth.Services;

public class AuthorisationService : IAuthorisationService
{
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public AuthorisationService(IMapper mapper, RoleManager<Role> roleManager, SignInManager<User> signInManager)
    {
        _roleManager = roleManager;
        _mapper = mapper;
        _signInManager = signInManager;
    }

    public async Task<IEnumerable<RoleDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var roles = await _roleManager.Roles.ToListAsync(cancellationToken) 
                   ?? throw new RoleNotFoundException();

        var rolesDto = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(roles);

        return rolesDto;
    }

    public async Task<RoleDto> GetAsync(Guid idUser)
    {
        var user = await _signInManager.UserManager.FindByIdAsync(idUser.ToString()) 
                   ?? throw new UserNotFoundException(idUser);
        
        var roleName = await _signInManager.UserManager.GetRolesAsync(user);

        var role = await _roleManager.Roles.FirstOrDefaultAsync(role => role.Name == roleName.ElementAt(0)) 
                   ?? throw new RoleNotFoundException(roleName.ElementAt(0));
        
        var roleDto = _mapper.Map<Role, RoleDto>(role);

        return roleDto;
    }

    public async Task DeleteAsync(Guid idRole)
    {
        var role = await _roleManager.Roles.FirstOrDefaultAsync(role => role.Id == idRole) 
                   ?? throw new RoleNotFoundException(idRole);

        var result = await _roleManager.DeleteAsync(role);
        if (!result.Succeeded) 
            throw new BadRequestException();
    }

    public async Task CreateAsync(RoleForCreatingDto roleDto)
    {
        if (roleDto is null)
            throw new NullDtoBadRequestException();
        
        var role = _mapper.Map<RoleForCreatingDto, Role>(roleDto);
        
        var result = await _roleManager.CreateAsync(role);
        if (!result.Succeeded) 
            throw new BadRequestException();
    }

    public async Task SetAsync(Guid idUser, RoleForSettingDto roleDto)
    {
        if (roleDto is null)
            throw new NullDtoBadRequestException();
        
        var user = await _signInManager.UserManager.FindByIdAsync(idUser.ToString())
                   ?? throw new UserNotFoundException(idUser);
        
        var role = await _roleManager.FindByNameAsync(roleDto.Name) 
                   ?? throw new RoleNotFoundException(roleDto.Name);
        
        var pastRole = await _signInManager.UserManager.GetRolesAsync(user);
        
        var result = await _signInManager.UserManager.RemoveFromRolesAsync(user, pastRole);
        if (!result.Succeeded) 
            throw new BadRequestException();
        
        result = await _signInManager.UserManager.AddToRoleAsync(user, role.ToString());
        if (!result.Succeeded) 
            throw new BadRequestException();
    }
}