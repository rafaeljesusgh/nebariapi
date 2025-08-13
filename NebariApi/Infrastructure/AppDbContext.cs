using Microsoft.EntityFrameworkCore;
using NebariApi.Models;

namespace NebariApi.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tree> Tress { get; set; }
}