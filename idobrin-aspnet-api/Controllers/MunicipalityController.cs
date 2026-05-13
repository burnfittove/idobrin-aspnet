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
    public async Task<ActionResult<MunicipalityReturn>> GetMunicipality(int id, CancellationToken cancellationToken)
    {
        var entity = await _municipalityService.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return NotFound();
        return Ok(entity);
    }
    
    [HttpGet("{id:int}/country")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<MunicipalityReturn>> GetMunicipalityWithCountry(int id, CancellationToken cancellationToken)
    {
        var entity = await _municipalityService.ReturnByIdWithCountryAsync(id, cancellationToken);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MunicipalityReturn>>> GetAllMunicipalities(
        CancellationToken cancellationToken)
    {
        var entity = await _municipalityService.ReturnAllAsync(cancellationToken);
        return Ok(entity);
    }
}