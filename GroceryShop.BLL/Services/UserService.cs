using AutoMapper;
using GroceryShop.BLL.Entity.DataTransferObjects.UserDto;
using GroceryShop.BLL.Interfaces;
using GroceryShop.DAL.Entities.Exceptions.BadRequestException;
using GroceryShop.DAL.Entities.Exceptions.NotFoundException;
using GroceryShop.DAL.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GroceryShop.BLL.Services;

public class UserService : IUserService
{
    private readonly SignInManager<User> _signInManager; 
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _signInManager = signInManager;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
       var users =  await _signInManager.UserManager.Users.ToListAsync(cancellationToken) 
                    ?? throw new UserNotFoundException();

       var usersDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

       return usersDto;
    }

    public async Task<UserDto> GetAsync(Guid idUser)
    {
        var user =  await _signInManager.UserManager.FindByIdAsync(idUser.ToString())
                     ?? throw new UserNotFoundException(idUser);

        var userDto = _mapper.Map<User, UserDto>(user);

        return userDto;
    }

    public async Task DeleteAsync(Guid idUser)
    {
        var user =  await _signInManager.UserManager.FindByIdAsync(idUser.ToString())
                    ?? throw new UserNotFoundException(idUser);
        
        await _signInManager.UserManager.DeleteAsync(user);
    }

    public async Task UpdateAsync(Guid idUser, UserForUpdatingDto userDto)
    {
        if (userDto is null)
            throw new NullDtoBadRequestException();
        
        var user = await _signInManager.UserManager.FindByIdAsync(idUser.ToString())
                   ?? throw new UserNotFoundException(idUser);

        var result = await _signInManager.CheckPasswordSignInAsync(user, userDto.Password, false);
        if (!result.Succeeded)
            throw new InvalidPasswordOrEmailBadRequestException();
        
        if (userDto.Email is not null)
        {
            var token = await _signInManager.UserManager.GenerateChangeEmailTokenAsync(user, userDto.Email);
            var emailResult = await _signInManager.UserManager.ChangeEmailAsync(user, userDto.Email, token);
            if (!emailResult.Succeeded)
                throw new BadRequestException();
        }
        if (userDto.PhoneNumber is not null)
        {
            var token = await _signInManager.UserManager.GenerateChangePhoneNumberTokenAsync(user, userDto.PhoneNumber);
            var phoneResult = await _signInManager.UserManager.ChangePhoneNumberAsync(user, userDto.PhoneNumber, token);
            if (!phoneResult.Succeeded)
                throw new BadRequestException();
        }
        if (userDto.NewPassword is not null)
        {
            var token = await _signInManager.UserManager.GeneratePasswordResetTokenAsync(user);
            var passwordResult = await _signInManager.UserManager.ChangePasswordAsync(user, userDto.NewPassword, token);
            if (!passwordResult.Succeeded)
               throw new BadRequestException();
        }
    }
}