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
    public async Task<ActionResult<UserReturn>> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _userService.ReturnByIdAsync(id, cancellationToken);
        return entity == null? NotFound() : Ok(entity);
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserReturn>>> ReturnAllAsync(
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
}