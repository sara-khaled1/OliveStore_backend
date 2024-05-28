using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controller;

public class ProductController : BaseController
{
    private IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductReadDto>> FindAll([FromQuery(Name ="searchBy")] string ?
    searchBy)
    {
     
        return Ok(_productService.FindAll(searchBy));
    }

    [HttpGet("{id}")]
    public ActionResult<ProductReadDto?> FindOne([FromRoute] Guid id)
    {
        ProductReadDto? foundProduct = _productService.FindOne(id);
        return Ok(foundProduct);
    }
    [HttpGet("/search/{categoryId}")]
    public ActionResult<ProductReadDto?> FindByCategory([FromRoute] Guid categoryId)
    {
        ProductReadDto? foundProduct = _productService.FindByCategory(categoryId);
        return Ok(foundProduct);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ProductReadDto> CreateOne([FromBody] ProductCreateDto product)
    {
        if (product is not null)
        {
            var createdProduct = _productService.CreateOne(product);
            return CreatedAtAction(nameof(CreateOne), createdProduct);
        }
        return BadRequest();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ProductReadDto> UpdateOne(Guid id, [FromBody] ProductReadDto updatedProduct)
    {
        ProductReadDto? product = _productService.UpdateOne(id, updatedProduct);
        if (product is null) return BadRequest();
        return CreatedAtAction(nameof(UpdateOne), product);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne([FromRoute] Guid id)
    {
        bool isDeleted = _productService.DeleteOne(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
