using idobrin_aspnet_logic.DTOs.Cart;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController(ICartService cartService) : ControllerBase
{
    private readonly ICartService _cartService = cartService;
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CartReturn>> ReturnCart(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _cartService.ReturnByIdAsync(id, cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpGet("/all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<CartReturn?>>> ReturnAllCart(
        CancellationToken cancellationToken = default)
    {
        var entities = await _cartService.ReturnAllAsync(cancellationToken);
        return entities == null ? NotFound() : Ok(entities);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CartReturn>> CreateCart(CartCreate cart,
        CancellationToken cancellationToken = default)
    {
        var entity = await _cartService.CreateAsync(cart, cancellationToken);
        return CreatedAtAction(nameof(ReturnCart), new { id = entity.Id }, entity);
    }

    [HttpPatch("{cartId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddItemToCart([FromRoute]int cartId, [FromQuery]int productId, [FromQuery]int quantity, CancellationToken cancellationToken = default)
    {
        var result = await _cartService.AddItemToCartAsync(cartId, productId, quantity, cancellationToken);
        return result ? Ok(result) : BadRequest();
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken = default)
    {
        var result = await _cartService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound(); 
    }
}