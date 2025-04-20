using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data.Contexts;
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<StatusEntity> Status { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
}