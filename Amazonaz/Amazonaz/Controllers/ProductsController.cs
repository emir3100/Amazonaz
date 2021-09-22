using Amazonaz.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
}


