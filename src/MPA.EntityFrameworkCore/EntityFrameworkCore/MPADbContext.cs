using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MPA.Entities;

namespace MPA.EntityFrameworkCore;

public class MPADbContext : AbpDbContext
{
    //Add DbSet properties for your entities...
    public DbSet<News> News { get; set; }
    public MPADbContext(DbContextOptions<MPADbContext> options)
        : base(options)
    {

    }
}
