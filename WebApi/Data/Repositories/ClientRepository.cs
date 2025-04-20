using WebApi.Data.Contexts;
using WebApi.Data.Entities;

namespace WebApi.Data.Repositories;

public class ClientRepository(DataContext context) : BaseRepository<ClientEntity>(context)
{
}
