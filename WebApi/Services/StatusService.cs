using WebApi.Data.Repositories;
using WebApi.Models;

namespace WebApi.Services;

public class StatusService(StatusRepository statusRepository)
{
    private readonly StatusRepository _statusRepository = statusRepository;

    //Hämtar alla status och mappar de
    public async Task<IEnumerable<Status>> GetAllStatusAsync()
    {
        var entities = await _statusRepository.GetAllAsync();
        var statuses = entities.Select(status => new Status { Id = status.Id, StatusName = status.StatusName });
        return statuses;
    }

    //Hämtar enskild status
    public async Task<Status?> GetStatusByIdAsync(int statusId)
    {
        var entity = await _statusRepository.GetAsync(x => x.Id == statusId);
        return entity == null ? null : new Status { Id = entity.Id, StatusName = entity.StatusName };
    }
}
