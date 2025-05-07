using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(UserService userService) : ControllerBase
{
    private readonly UserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(string userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddUserFormData userFormData)
    {
        if (!ModelState.IsValid)
            return BadRequest(userFormData);

        var result = await _userService.CreateUserAsync(userFormData);
        return result ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserFormData userFormData)
    {
        if (!ModelState.IsValid)
            return BadRequest(userFormData);

        var result = await _userService.UpdateUserAsync(userFormData);
        return result ? Ok(result) : NotFound();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            return BadRequest();

        var result = await _userService.DeleteUserAsync(userId);
        return result ? Ok(result) : NotFound();
    }
}
