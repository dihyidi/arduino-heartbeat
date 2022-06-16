using HeartBeatMonitoringApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeartBeatMonitoringApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PulseController : ControllerBase
{
    private readonly IPulseService service;

    public PulseController(IPulseService service)
    {
        this.service = service;
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetAll(int userId)
    {
        var result = await service.GetAllAsync(userId);

        return Ok(result);
    }
    
    [HttpPost("{userId:int}")]
    public IActionResult Start(int userId)
    {
        service.Start(userId);

        return Ok();
    }
}