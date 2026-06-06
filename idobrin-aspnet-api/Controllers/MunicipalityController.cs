using idobrin_aspnet_logic.DTOs.Municipality;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MunicipalityController(IMunicipalityService municipalityService) : ControllerBase
{
    private readonly IMunicipalityService _municipalityService = municipalityService;
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<MunicipalityReturn>> ReturnMunicipality(int id, CancellationToken cancellationToken)
    {
        var entity = await _municipalityService.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return NotFound();
        return Ok(entity);
    }
    
    [HttpGet("{id:int}/country")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<MunicipalityReturn>> ReturnMunicipalityWithCountry(int id, CancellationToken cancellationToken)
    {
        var entity = await _municipalityService.ReturnByIdWithCountryAsync(id, cancellationToken);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MunicipalityReturn>>> ReturnAllMunicipalities(
        CancellationToken cancellationToken)
    {
        var entity = await _municipalityService.ReturnAllAsync(cancellationToken);
        return Ok(entity);
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken = default)
    {
        var result = await _municipalityService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound(); 
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MunicipalityReturn>> CreateProduct(MunicipalityCreate municipality, CancellationToken cancellationToken = default)
    {
        var entity = await _municipalityService.CreateAsync(municipality, cancellationToken);
        return CreatedAtAction(nameof(ReturnMunicipality), new { id = entity.Id }, entity);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct(int id, MunicipalityUpdate municipality,
        CancellationToken cancellationToken = default)
    {
        if (id != municipality.Id) return BadRequest("ID mismatch");
        
        var result = await _municipalityService.UpdateAsync(id, municipality, cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }
}