using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController(ClientService clientService) : ControllerBase
{
    private readonly ClientService _clientService = clientService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clients = await _clientService.GetAllClientsAsync();
        return Ok(clients);
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> Get(string clientId)
    {
        var client = await _clientService.GetClientByIdAsync(clientId);
        return client == null ? NotFound() : Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddClientFormData clientFormData)
    {
        if (!ModelState.IsValid)
            return BadRequest(clientFormData);

        var result = await _clientService.CreateClientAsync(clientFormData);
        return result ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateClientFormData clientFormData)
    {
        if (!ModelState.IsValid)
            return BadRequest(clientFormData);

        var result = await _clientService.UpdateClientAsync(clientFormData);
        return result ? Ok(result) : NotFound();
    }

    [HttpDelete("{clientId}")]
    public async Task<IActionResult> Delete(string clientId)
    {
        if (string.IsNullOrEmpty(clientId))
            return BadRequest();

        var result = await _clientService.DeleteClientAsync(clientId);
        return result ? Ok(result) : NotFound();
    }
}