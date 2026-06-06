using idobrin_aspnet_logic.DTOs.Country;
using idobrin_aspnet_logic.DTOs.User;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController(ICountryService countryService) : ControllerBase
{
    private readonly ICountryService _countryService = countryService;

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryReturn>> ReturnCountry(int id, CancellationToken cancellationToken)
    {
        var entity = await _countryService.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return NotFound();
        return Ok(entity);
    }
    
    [HttpGet("{id:int}/municipalities")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CountryReturn>> GetCountryWithMunicipalities(int id, CancellationToken cancellationToken)
    {
        var entity = await _countryService.ReturnCountryByIdWithMunicipalitiesAsync(id, cancellationToken);
        if (entity == null) return NotFound();
        return Ok(entity);
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<CountryReturn>> ReturnAllCountries(CancellationToken cancellationToken)
    {
        var entity = await _countryService.ReturnAllAsync(cancellationToken);
        return Ok(entity);
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken = default)
    {
        var result = await _countryService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound(); 
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryReturn>> CreateProduct(CountryCreate country, CancellationToken cancellationToken = default)
    {
        var entity = await _countryService.CreateAsync(country, cancellationToken);
        return CreatedAtAction(nameof(ReturnCountry), new { id = entity.Id }, entity);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct(int id, CountryUpdate country,
        CancellationToken cancellationToken = default)
    {
        if (id != country.Id) return BadRequest("ID mismatch");
        
        var result = await _countryService.UpdateAsync(id, country, cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }
}