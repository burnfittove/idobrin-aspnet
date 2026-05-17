using aspnet_domain.Entities;
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryReturn>> ReturnCategory(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _categoryService.ReturnByIdAsync(id, cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<CategoryReturn>>> ReturnAllProducts(
        CancellationToken cancellationToken = default)
    {
        var entity = await _categoryService.ReturnAllAsync(cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpGet("{id:int}/products")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryWithProductsReturn>> ReturnCategoryWithProducts(int id,
        CancellationToken cancellationToken = default)
    {
        var entity = await _categoryService.ReturnCategoryWithProductsAsync(id, cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryReturn>> CreateCategory([FromBody] CategoryCreate category,
        CancellationToken cancellationToken = default)
    {
        var entity = await _categoryService.CreateAsync(category, cancellationToken);
        return CreatedAtAction(nameof(ReturnCategory), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken = default)
    {
        var result = await _categoryService.DeleteAsync(id, cancellationToken);
        
        return result ? NoContent() : NotFound();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdate category,
        CancellationToken cancellationToken = default)
    {
        if (id != category.Id) return BadRequest("ID mismatch");
        var result = await _categoryService.UpdateAsync(id, category, cancellationToken);
        return result ? NoContent() : NotFound();
    }
}