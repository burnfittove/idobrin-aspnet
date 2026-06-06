using idobrin_aspnet_logic.DTOs.User;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserReturn>> ReturnUser(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _userService.ReturnByIdAsync(id, cancellationToken);
        return entity == null? NotFound() : Ok(entity);
    }

    [HttpGet("all")]
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
    public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken = default)
    {
        var result = await _userService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound(); 
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserReturn>> CreateProduct(UserCreate user, CancellationToken cancellationToken = default)
    {
        var entity = await _userService.CreateAsync(user, cancellationToken);
        return CreatedAtAction(nameof(ReturnUser), new { id = entity.Id }, entity);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct(int id, UserUpdate user,
        CancellationToken cancellationToken = default)
    {
        if (id != user.Id) return BadRequest("ID mismatch");
        
        var result = await _userService.UpdateAsync(id, user, cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }
}