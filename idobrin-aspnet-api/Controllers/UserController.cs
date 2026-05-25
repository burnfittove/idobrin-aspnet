using idobrin_aspnet_logic.DTOs;
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

    [HttpGet("{id:int}/cart")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserWithCartReturn>> ReturnCartAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _userService.ReturnCartByIdAsync(id, cancellationToken);
        return entity == null? NotFound() : Ok(entity);
    }

    [HttpPut("{id:int}/cart")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddItemToCartAsync(int id, [FromQuery] int productId, [FromQuery] int quantity,
        CancellationToken cancellationToken = default)
    {
        var result = await _userService.AddItemToCart(id, productId, quantity, cancellationToken);
    }
}