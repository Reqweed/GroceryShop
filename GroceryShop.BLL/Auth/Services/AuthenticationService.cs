using System.Security.Claims;
using AutoMapper;
using GroceryShop.BLL.Auth.Interfaces;
using GroceryShop.BLL.Entities.DataTransferObjects.AuthenticationDto;
using GroceryShop.BLL.Entities.DataTransferObjects.UserDto;
using GroceryShop.DAL.Entities.Exceptions.BadRequestException;
using GroceryShop.DAL.Entities.Exceptions.NotFoundException;
using GroceryShop.DAL.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace GroceryShop.BLL.Auth.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    
    public AuthenticationService(IMapper mapper, IJwtService jwtService, SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _jwtService = jwtService;
        _signInManager = signInManager;
    }
    
    public async Task<AuthenticationResponseDto> RegistrationAsync(UserForRegistrationDto userDto)
    {
        if (userDto is null)
            throw new NullDtoBadRequestException();
        
        var user = _mapper.Map<UserForRegistrationDto, User>(userDto);

        user.RefreshToken = _jwtService.CreateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        
        var result = await _signInManager.UserManager.CreateAsync(user, userDto.Password);
        if (!result.Succeeded)
            throw new BadRequestException();

        user = await _signInManager.UserManager.FindByEmailAsync(user.Email) 
               ?? throw new UserNotFoundException(user.Email);

        return new AuthenticationResponseDto
        {
            Token = _jwtService.CreateToken(user),
            RefreshToken = user.RefreshToken,
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
        };
    }

    public async Task<AuthenticationResponseDto> LoginAsync(UserForLoginDto userDto)
    {
        if (userDto is null)
            throw new NullDtoBadRequestException();
        
        var user = await _signInManager.UserManager.FindByEmailAsync(userDto.Email) 
                          ?? throw new InvalidPasswordOrEmailBadRequestException();

        var result = await _signInManager.CheckPasswordSignInAsync(user, userDto.Password, false);
        if (!result.Succeeded)
            throw new InvalidPasswordOrEmailBadRequestException();
        
        user.RefreshToken = _jwtService.CreateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        
        var updateResult = await _signInManager.UserManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
            throw new BadRequestException();

        return new AuthenticationResponseDto
        {
            Token = _jwtService.CreateToken(user),
            RefreshToken = user.RefreshToken,
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
        };
    }

    public async Task<AuthenticationResponseDto> UpdateTokenAsync(AuthenticationRefreshDto authenticationRefreshDto)
    {
        if (authenticationRefreshDto is null)
            throw new NullDtoBadRequestException();
        
        var principal = _jwtService.GetPrincipalFromExpiredToken(authenticationRefreshDto.Token);

        var idUser = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (idUser is null)
            throw new TokenBadRequestException();
        
        var user = await _signInManager.UserManager.FindByIdAsync(idUser) 
                   ?? throw new UserNotFoundException(Guid.Parse(idUser));
        
        if (user.RefreshToken is null || user.RefreshToken != authenticationRefreshDto.RefreshToken)
            throw new RefreshTokenBadRequestException();
        
        var newToken = _jwtService.CreateToken(user);

        if (user.RefreshTokenExpiryTime < DateTime.UtcNow.AddDays(2))
        {
            var newRefreshToken = _jwtService.CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
        
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        
            var updateResult = await _signInManager.UserManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                throw new BadRequestException();
        }
        
        return new AuthenticationResponseDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Token = newToken,
            RefreshToken = user.RefreshToken
        };
    }
}