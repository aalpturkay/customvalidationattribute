using Microsoft.EntityFrameworkCore;
using ValidationExample.Opinions;

namespace ValidationExample.Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }
    
    public DbSet<Opinion> Opinions { get; set; }
}