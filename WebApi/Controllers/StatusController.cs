using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController(StatusService statusService) : ControllerBase
{
    private readonly StatusService _statusService = statusService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var statuses = await _statusService.GetAllStatusAsync();
        return Ok(statuses);
    }

}
