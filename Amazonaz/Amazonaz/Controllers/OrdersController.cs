using Amazonaz.Server.Data;
using Amazonaz.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amazonaz.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbConext;

    public OrdersController(ApplicationDbContext applicationDbConext)
    {
        this._applicationDbConext = applicationDbConext;
    }


    [HttpGet]
    public async Task<IEnumerable<OrderModel>> GetAllOrders()
    {
        return await _applicationDbConext.Orders.ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var order = await _applicationDbConext.Orders.FindAsync(id);

        if (order is null)
            return NotFound();

        return Ok(order);
    }

    [HttpGet("user/{userId}")]
    public async Task<IEnumerable<OrderModel>> GetOrdersByUserId(Guid userId)
    {
        return await _applicationDbConext.Orders.Where(x => x.UserId == userId).ToArrayAsync();
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(OrderModel order)
    {
        if (order.Quantity < 1)
            return BadRequest();

        var user = await _applicationDbConext.Users.FindAsync(order.UserId);

        if (user is null)
            return BadRequest();

        var product = await _applicationDbConext.Products.FindAsync(order.ProductId);

        if(product is null)
            return BadRequest();

        if (order.Quantity > product.TotalSupply || order.Quantity < 1)
            return BadRequest();

        product.TotalSupply = product.TotalSupply - order.Quantity;
        _applicationDbConext.Products.Update(product);
        order.Id = Guid.NewGuid();
        order.OrderDate = DateTime.UtcNow;
        
        _applicationDbConext.Add(order);
        
        await _applicationDbConext.SaveChangesAsync();

        return Created($"api/products/{order.Id}", order);
    }
}

