﻿using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectService.GetAllProjectsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromQuery]string id)
    {
        var result = await _projectService.GetProjectByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddProjectFormData formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _projectService.CreateProjectAsync(formData);
        return result ? Ok(result) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditProjectFormData formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _projectService.UpdateProjectAsync(formData);
        return result ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _projectService.DeleteProjectAsync(id);
        return result ? Ok() : NotFound();
    }
}
