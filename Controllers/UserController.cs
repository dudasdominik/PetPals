using Microsoft.AspNetCore.Mvc;
using PetPals.Models;
using PetPals.Models.DTOs;
using PetPals.Services;

namespace PetPals.Controllers;
[ApiController]
[Route("/api/v1/users/")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<UserModel>> ShowAllUsers()
    {
        return await _userService.GetAllUsers();
    }

    [HttpGet("{userId}")]
    public async Task<UserModel> ShowUserById(Guid userId)
    {
        return await _userService.GetUserById(userId);
    }

    [HttpPost("new")]
    public async Task<UserModel> PostNewUser([FromBody] CreateUserDTO user)
    {
        return await _userService.CreateUser(user);
    }

    [HttpPost("login")]
    public async Task<bool> LogInUser([FromBody] LoginCredentialsDTO creds)
    {
        var user = await _userService.SignInUser(creds);
        if (user == null) return false;
        return true;
    }
}