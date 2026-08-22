using idobrin_aspnet_logic.DTOs.Address;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController(IAddressService addressService, ILogger<AddressController> logger) : ControllerBase
{
    private readonly IAddressService _addressService = addressService;
    private readonly ILogger<AddressController> _logger = logger;

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<AddressReturn>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var entities = await _addressService.ReturnAll(cancellationToken);
        _logger.LogInformation("Returning {count} addresses", entities.Count());
        return entities == null ? NotFound() : Ok(entities);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddressReturn>> ReturnAddress(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _addressService.ReturnByIdAsync(id, cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddressReturn>> CreateAddress(AddressCreate address, CancellationToken cancellationToken = default)
    {
        var entity = await _addressService.CreateAsync(address, cancellationToken);
        return CreatedAtAction(nameof(ReturnAddress), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAddress(int id, CancellationToken cancellationToken = default)
    {
        var result = await _addressService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound();
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct(int id, AddressUpdate address,
        CancellationToken cancellationToken = default)
    {
        if (id != address.Id) return BadRequest("ID mismatch");
        
        var result = await _addressService.UpdateAsync(id, address, cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }
}