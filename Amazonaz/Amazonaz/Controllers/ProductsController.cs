using Amazonaz.Server.Data;
using Amazonaz.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amazonaz.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbConext;

    public ProductsController(ApplicationDbContext applicationDbConext)
    {
        this._applicationDbConext = applicationDbConext;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductModel>> GetAllProducts()
    {
        return await _applicationDbConext.Products.ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _applicationDbConext.Products.FindAsync(id);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductModel product)
    {
        var user = await _applicationDbConext.Users.FindAsync(product.CreatedById);

        if (user is null)
            return BadRequest();
        
        product.Id = Guid.NewGuid();
        product.CreationDate = DateTime.UtcNow;
        _applicationDbConext.Add(product);
        await _applicationDbConext.SaveChangesAsync();

        return Created($"api/products/{product.Id}", product);
    }
}


