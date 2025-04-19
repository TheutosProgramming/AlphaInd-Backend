using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public interface IStatusService
{
    Task<Status> GetStatusByIdAsync(int id);
    Task<IEnumerable<Status>> GetStatusesAsync();
    Task<Status> GetStatusesByStatusNameAsync(string statusName);
}

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;


    public async Task<Status> GetStatusByIdAsync(int id)
    {
        var entity = await _statusRepository.GetAsync(x => x.Id == id);
        return StatusFactory.ToModel(entity);
    }

    public async Task<IEnumerable<Status>> GetStatusesAsync()
    {
        var entities = await _statusRepository.GetAllAsync(sortBy: x => x.Id);
        var statuses = entities.Select(StatusFactory.ToModel);

        return statuses;
    }

    public async Task<Status> GetStatusesByStatusNameAsync(string statusName)
    {
        var entity = await _statusRepository.GetAsync(x => x.StatusName.ToLower() == statusName.ToLower());
        return entity == null ? null! : StatusFactory.ToModel(entity);
    }
}