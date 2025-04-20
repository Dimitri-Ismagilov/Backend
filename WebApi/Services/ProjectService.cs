using WebApi.Data.Entities;
using WebApi.Data.Repositories;
using WebApi.Models;

namespace WebApi.Services;

public class ProjectService(ProjectRepository projectRepository)
{
    private readonly ProjectRepository _projectRepository = projectRepository;

    public async Task<bool> CreateProjectAsync(AddProjectFormData projectFormData)
    {
        if (projectFormData == null)
            return false;

        var entity = new ProjectEntity
        {
            ProjectName = projectFormData.ProjectName,
            Description = projectFormData.Description,
            StartDate = projectFormData.StartDate,
            EndDate = projectFormData.EndDate,
            Budget = projectFormData.Budget,
            ClientId = projectFormData.ClientId,
            UserId = projectFormData.UserId,
            StatusId = 1,
        };

        var relust = await _projectRepository.AddAsync(entity);
        return relust;
    }

    public async Task<bool> UpdateProjectAsync(UpdateProjectFormData projectFormData)
    {
        if (projectFormData == null)
            return false;

        var entity = new ProjectEntity
        {
            Id = projectFormData.Id,
            ProjectName = projectFormData.ProjectName,
            Description = projectFormData.Description,
            StartDate = projectFormData.StartDate,
            EndDate = projectFormData.EndDate,
            Budget = projectFormData.Budget,
            ClientId = projectFormData.ClientId,
            UserId = projectFormData.UserId,
            StatusId = projectFormData.StatusId,
        };

        var relust = await _projectRepository.UpdateAsync(entity);
        return relust;
    }

    public async Task<bool> DeleteProjectAsync(string projectId)
    {
        if (string.IsNullOrEmpty(projectId))
            return false;
        var result = await _projectRepository.DeleteAsync(x => x.Id == projectId);
        return result;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync(bool orderByDescending = false)
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(entity => new Project 
        { 
            Id = entity.Id,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Budget = entity.Budget,
            CreatedDate = entity.CreatedDate,
            Client = new Client
            {
                Id = entity.Client.Id,
                ClientName = entity.Client.ClientName,
            },
            User = new User
            {
                Id = entity.User.Id,
                FirstName = entity.User.FirstName,
                LastName = entity.User.LastName,
            },
            Status = new Status
            {
                Id = entity.Status.Id,
                StatusName = entity.Status.StatusName,
            }
        });

        return orderByDescending
            ? projects.OrderByDescending(entity => entity.CreatedDate)
            : projects.OrderBy(entity => entity.CreatedDate);
    }

    public async Task<Project?> GetProjectByIdAsync(string projectId)
    {
        var entity = await _projectRepository.GetAsync(x => x.Id == projectId);
        return entity == null ? null : new Project
        {
            Id = entity.Id,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Budget = entity.Budget,
            CreatedDate = entity.CreatedDate,
            Client = new Client
            {
                Id = entity.Client.Id,
                ClientName = entity.Client.ClientName,
            },
            User = new User
            {
                Id = entity.User.Id,
                FirstName = entity.User.FirstName,
                LastName = entity.User.LastName,
            },
            Status = new Status
            {
                Id = entity.Status.Id,
                StatusName = entity.Status.StatusName,
            }
        };
    }
}
