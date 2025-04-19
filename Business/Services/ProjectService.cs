using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(AddProjectFormData formData, string defaultStatus = "Started");
    Task<bool> DeleteProjectAsync(string id);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(string id);
    Task<Project> GetProjectByNameAsync(string projectName);
    Task<bool> UpdateProjectAsync(EditProjectFormData formData);
}

public class ProjectService(IProjectRepository projectRepository, IStatusService statusService) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IStatusService _statusService = statusService;

    public async Task<bool> CreateProjectAsync(AddProjectFormData formData, string defaultStatus = "Started")
    {
        if (formData == null)
            return false;

        var projectEntity = ProjectFactory.ToEntity(formData);
        var status = await _statusService.GetStatusesByStatusNameAsync(defaultStatus);

        if (status != null && status.Id != 0)
            projectEntity.StatusId = status.Id;
        else
            return false;

        var result = await _projectRepository.AddAsync(projectEntity);
        return result;
    }

    public async Task<Project> GetProjectByIdAsync(string id)
    {
        var entity = await _projectRepository.GetAsync(
            x => x.Id == id,
            i => i.Client,
            i => i.Member,
            i => i.Status
            );
        return ProjectFactory.ToModel(entity);
    }

    public async Task<Project> GetProjectByNameAsync(string projectName)
    {
        var entity = await _projectRepository.GetAsync(
            x => x.ProjectName == projectName,
            i => i.Client,
            i => i.Member,
            i => i.Status
            );
        return ProjectFactory.ToModel(entity);
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync(
            orderByDescending: true,
            sortBy: x => x.Created,
            filterBy: null,
            i => i.Member,
            i => i.Client,
            i => i.Status
        );

        var projects = entities.Select(ProjectFactory.ToModel);

        return projects;
    }

    public async Task<bool> UpdateProjectAsync(EditProjectFormData formData)
    {
        if (formData == null)
            return false;

        if (!await _projectRepository.ExistsAsync(x => x.Id == formData.Id))
            return false;

        var projectEntity = ProjectFactory.ToEntity(formData);
        var result = await _projectRepository.UpdateAsync(projectEntity);

        return result;
    }

    public async Task<bool> DeleteProjectAsync(string id)
    {
        var result = await _projectRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
