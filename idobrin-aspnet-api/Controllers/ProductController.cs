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
        
        var entity = await _productService.UpdateAsync(id, product, cancellationToken);
        return entity == null ? NotFound() : Ok(entity);
    }
}