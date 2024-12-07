using Microsoft.EntityFrameworkCore;

namespace MPA.EntityFrameworkCore;

public static class DbContextOptionsConfigurer
{
    public static void Configure(
        DbContextOptionsBuilder<MPADbContext> dbContextOptions,
        string connectionString
        )
    {
        /* This is the single point to configure DbContextOptions for MPADbContext */
        dbContextOptions.UseSqlServer(connectionString);
    }
}
