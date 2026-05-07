using idobrin_aspnet_logic.DTOs.Country;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController(ICountryService countryService) : ControllerBase
{
    private readonly ICountryService _countryService = countryService;

    [HttpGet("{id}")]
    public async Task<ActionResult<CountryReturn>> GetCountry(int id, CancellationToken cancellationToken)
    {
        var entity = await _countryService.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpGet]
    public async Task<ActionResult<CountryReturn>> GetAllCountries(CancellationToken cancellationToken)
    {
        var entity = await _countryService.ReturnAllAsync(cancellationToken);
        return Ok(entity);
    }
}