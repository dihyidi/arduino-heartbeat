using HeartBeatMonitoringApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeartBeatMonitoringApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService service;

    public UsersController(IUserService service)
    {
        this.service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetAsync(id);

        return Ok(result);
    }
}