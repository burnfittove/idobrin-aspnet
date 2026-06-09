using System.Security.Claims;
using idobrin_aspnet_api.Security;
using idobrin_aspnet_logic.DTOs.User;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, IConfiguration config) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly IConfiguration _config = config;

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserReturn>> ReturnUser(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _userService.ReturnByIdAsync(id, cancellationToken);
        return entity == null? NotFound() : Ok(entity);
    }
    
    [HttpGet("all")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserReturn>>> ReturnAll(
        CancellationToken cancellationToken = default)
    {
        var entities = await _userService.ReturnAllAsync(cancellationToken);
        return entities == null? NotFound() : Ok(entities);
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken = default)
    {
        var result = await _userService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound(); 
    }
    
    // [HttpPost]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<UserReturn>> CreateUser(UserCreate user, CancellationToken cancellationToken = default)
    // {
    //     var entity = await _userService.CreateAsync(user, cancellationToken);
    //     return CreatedAtAction(nameof(ReturnUser), new { id = entity.Id }, entity);
    // }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUser(int id, UserUpdate user,
        CancellationToken cancellationToken = default)
    {
        if (id != user.Id) return BadRequest("ID mismatch");
        
        var result = await _userService.UpdateAsync(id, user, cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserCreate>> Register(UserRegister user, CancellationToken cancellationToken = default)
    {
        // Check if the username exists in the database
        var trimmedUsername = user.Username.Trim();
        if (await _userService.UsernameExistsAsync(trimmedUsername, cancellationToken))
            BadRequest("Username already exists");
        
        // Hash the password
        var b64salt = PasswordHashProvider.GetSalt();
        var b64hash = PasswordHashProvider.GetHash(user.Password, b64salt);
        
        // Create user
        var entity = user.ToCreateDto(b64salt, b64hash, 1);
        
        // Add the user
        await _userService.CreateAsync(entity, cancellationToken);
        return Ok(entity);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(UserLogin user, CancellationToken cancellationToken = default)
    {
        // Return the user and check if it exists
        var entity = await _userService.ReturnByUsername(user.Username, cancellationToken);
        if (entity == null) return BadRequest("Incorrect username");
        
        Console.WriteLine(entity.Role);
        
        // Check password
        var b64hash = PasswordHashProvider.GetHash(user.Password, entity.PwdSalt);
        if (b64hash != entity.PwdHash) return BadRequest("Incorrect password");
        
        // Create JWT
        var secureKey = _config["JWT:SecureKey"];
        var serializedToken = JwtTokenProvider.CreateToken(secureKey, 10, entity.Role);
        
        return Ok(serializedToken);
    }
}