using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesRegisterRest.Auth;
using MoviesRegisterRest.Auth.Model;

namespace MoviesRegisterRest.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api")]
public class AuthController : ControllerBase
{
    private readonly UserManager<MoviesWebUser> _userManager;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(UserManager<MoviesWebUser> userManager, IJwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
	{
        var user = await _userManager.FindByNameAsync(registerUserDto.UserName);
        if (user != null)
        {
            return BadRequest("User already exists!");
        }

        var newUser = new MoviesWebUser
        {
            Email = registerUserDto.Email,
            UserName = registerUserDto.UserName
        };
        var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
        if (!createUserResult.Succeeded)
        {
            return BadRequest("User could not be created!");
        }

        await _userManager.AddToRoleAsync(newUser, MoviesWebRoles.Director);

        return CreatedAtAction(nameof(Register), new UserDto(newUser.Id, newUser.UserName, newUser.Email));
	}

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        if (user == null)
        {
            return BadRequest("User name or password is invalid!");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!isPasswordValid)
        {
            return BadRequest("User name or password is invalid!");
        }

        user.ForceRelogin = false;
        await _userManager.UpdateAsync(user);

        //valid user
        var roles = await _userManager.GetRolesAsync(user);

        var accessToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);
        var refreshToken = _jwtTokenService.CreateRefreshToken(user.Id);

        return Ok(new SuccessfulLoginDto(accessToken, refreshToken));
    }

    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshAccessToken(RefreshAccessTokenDto refreshAccessTokenDto)
    {
        if(!_jwtTokenService.TryParseRefreshToken(refreshAccessTokenDto.RefreshToken, out var claims))
        {
            return BadRequest("Could not parse token!");
        }

        var userId = claims.FindFirstValue(JwtRegisteredClaimNames.Sub);

        var user = await _userManager.FindByIdAsync(userId);
        if(user == null)
        {
            return BadRequest("Invalid token!");
        }

        if(user.ForceRelogin)
        {
            return BadRequest();
        }

        var roles = await _userManager.GetRolesAsync(user);

        var accessToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);
        var refreshToken = _jwtTokenService.CreateRefreshToken(user.Id);

        return Ok(new SuccessfulLoginDto(accessToken, refreshToken));
    }

    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> LogOut(RefreshAccessTokenDto refreshAccessTokenDto)
    {
        if (!_jwtTokenService.TryParseRefreshToken(refreshAccessTokenDto.RefreshToken, out var claims))
        {
            return BadRequest("Could not parse token!");
        }

        var userId = claims.FindFirstValue(JwtRegisteredClaimNames.Sub);

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return BadRequest("Not logged in!");
        }

        user.ForceRelogin = true;
        await _userManager.UpdateAsync(user);

        return Ok("Logged out!");
    }
}

