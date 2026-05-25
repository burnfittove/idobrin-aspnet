using idobrin_aspnet_logic.DTOs.Products;
using idobrin_aspnet_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ProductReturn>> ReturnProduct(int id, CancellationToken cancellationToken)
    {
        var entity = await _productService.ReturnByIdAsync(id, cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductReturn>>> ReturnAllProducts(CancellationToken cancellationToken)
    {
        var entity = await _productService.ReturnAllAsync(cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpGet("{id:int}/categories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ProductWithCategoriesReturn>> ReturnProductWithCategories(int id,
        CancellationToken cancellationToken = default)
    {
        var entity = await _productService.ReturnProductWithCategoriesAsync(id, cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken = default)
    {
        var result = await _productService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound(); 
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductReturn>> CreateProduct(ProductCreate product, CancellationToken cancellationToken = default)
    {
        var entity = await _productService.CreateAsync(product, cancellationToken);
        return CreatedAtAction(nameof(ReturnProduct), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct(int id, ProductUpdate product,
        CancellationToken cancellationToken = default)
    {
        if (id != product.id) return BadRequest("ID mismatch");
        
        var result = await _productService.UpdateAsync(id, product, cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPatch("{id:int}/addCategory")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCategory(int id, [FromQuery] int categoryId,
        CancellationToken cancellationToken = default)
    {
        if (categoryId == null) return BadRequest("No category provided.");
        if (!await _productService.ExistsAsync(id, cancellationToken)) return NotFound("No product with that ID");

        var result = await _productService.AddCategory(id, categoryId, cancellationToken);
        return result == null ? NotFound("Product or category ID not found.") : Ok(result);
    }
    
    [HttpPatch("{id:int}/removeCategory")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveCategory(int id, [FromQuery] int categoryId,
        CancellationToken cancellationToken = default)
    {
        if (categoryId == null) return BadRequest("No category provided.");

        var result = await _productService.RemoveCategory(id, categoryId, cancellationToken);
        return result == null ? NotFound("No product with that ID") : Ok(result);
    }
}