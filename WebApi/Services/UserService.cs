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
        var users = entities.Select(user => new User { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, });
        return users;
    }
}
