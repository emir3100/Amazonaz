using System.Net;
using Amazonaz.Server.Data;
using Amazonaz.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amazonaz.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbConext;

    public UsersController(ApplicationDbContext applicationDbConext)
    {
        this._applicationDbConext = applicationDbConext;
    }

    [HttpGet]
    public async Task<IEnumerable<UserModel>> GetAllUsers()
    {
        return await _applicationDbConext.Users.ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _applicationDbConext.Users.FindAsync(id);

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser(UserModel user)
    {
        user.Id = Guid.NewGuid();
        _applicationDbConext.Add(user);
        await _applicationDbConext.SaveChangesAsync();

        return Created($"api/users/{user.Id}", user);

    }
}
    