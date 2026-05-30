using idobrin_aspnet_logic.DTOs.Address;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController(IAddressService addressService) : ControllerBase
{
    private readonly IAddressService _addressService = addressService;

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<AddressReturn>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var entities = await _addressService.ReturnAllAsync(cancellationToken);
        return entities == null ? NotFound() : Ok(entities);
    }
}