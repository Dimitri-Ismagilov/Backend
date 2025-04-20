using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(ProjectService projectService) : ControllerBase
{

    private readonly ProjectService _projectService = projectService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllProjectsAsync(orderByDescending: true);
        return Ok(projects);
    }

    [HttpGet("{projectId}")]
    public async Task<IActionResult> Get(string projectId)
    {
        var project = await _projectService.GetProjectByIdAsync(projectId);
        return project == null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddProjectFormData projectFormData)
    {
        if (!ModelState.IsValid)
            return BadRequest(projectFormData);
        var result = await _projectService.CreateProjectAsync(projectFormData);
        return result ? Ok(result) : BadRequest();
    }

    [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectFormData projectFormData)
    {
        if (!ModelState.IsValid)
            return BadRequest(projectFormData);

        var result = await _projectService.UpdateProjectAsync(projectFormData);
        return result ? Ok(result) : NotFound();
    }

    [HttpDelete("{projectId}")]
    public async Task<IActionResult> Delete(string projectId)
    {
        if (string.IsNullOrEmpty(projectId))
            return BadRequest();

        var result = await _projectService.DeleteProjectAsync(projectId);
        return result ? Ok(result) : NotFound();
    }
}
