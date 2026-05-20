using idobrin_aspnet_logic.DTOs;
using idobrin_aspnet_logic.DTOs.User;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, ICartService cartService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly ICartService _cartService = cartService;

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserReturn>> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _userService.ReturnByIdAsync(id, cancellationToken);
        return entity == null? NotFound() : Ok(entity);
    }

    [HttpGet("{id:int}/cart")]
    public async Task<ActionResult<CartReturn>> ReturnCartAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _userService.ReturnCartByIdAsync(id, cancellationToken);
        return entity == null? NotFound() : Ok(entity);
    }
}