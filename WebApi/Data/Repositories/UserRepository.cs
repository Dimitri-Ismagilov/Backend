using WebApi.Data.Contexts;
using WebApi.Data.Entities;

namespace WebApi.Data.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context)
{
}
