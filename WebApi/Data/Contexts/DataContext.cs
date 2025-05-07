using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;
using WebApi.Models;

namespace WebApi.Data.Contexts;
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<StatusEntity> Status { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<WebApi.Models.Client> Client { get; set; } = default!;
}