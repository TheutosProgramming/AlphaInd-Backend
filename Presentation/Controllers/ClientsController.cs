﻿using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController(IClientService clientService) : ControllerBase
{
    private readonly IClientService _clientService = clientService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _clientService.GetClientsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _clientService.GetClientsByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }
}
