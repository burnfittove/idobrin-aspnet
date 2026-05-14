using idobrin_aspnet_logic.DTOs.Category;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CategoryReturn>> ReturnCategory(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _categoryService.ReturnByIdAsync(id, cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }
}