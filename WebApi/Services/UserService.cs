using WebApi.Data.Entities;
using WebApi.Data.Repositories;
using WebApi.Models;

namespace WebApi.Services;

public class UserService(UserRepository userRepository)
{
    private readonly UserRepository _userRepository = userRepository;

    //Hämtar alla users och mappar de
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var entities = await _userRepository.GetAllAsync();
        return entities.Select(user => new User
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
        });
    }

    public async Task<User?> GetUserByIdAsync(string userId)
    {
        var entity = await _userRepository.GetAsync(x => x.Id == userId);
        return entity == null ? null : new User
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
        };
    }

    public async Task<bool> CreateUserAsync(AddUserFormData userFormData)
    {
        if (userFormData == null)
            return false;

        var entity = new UserEntity
        {
            FirstName = userFormData.FirstName,
            LastName = userFormData.LastName
        };

        return await _userRepository.AddAsync(entity);
    }

    public async Task<bool> UpdateUserAsync(UpdateUserFormData userFormData)
    {
        if (userFormData == null)
            return false;

        var entity = new UserEntity
        {
            Id = userFormData.Id,
            FirstName = userFormData.FirstName,
            LastName = userFormData.LastName
        };

        return await _userRepository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteUserAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            return false;

        return await _userRepository.DeleteAsync(x => x.Id == userId);
    }
}
