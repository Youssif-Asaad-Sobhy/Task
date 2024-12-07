using MPA.Configuration;
using MPA.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MPA.EntityFrameworkCore;

/* This class is needed to run EF Core PMC commands. Not used anywhere else */
public class MPADbContextFactory : IDesignTimeDbContextFactory<MPADbContext>
{
    public MPADbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<MPADbContext>();
        var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        DbContextOptionsConfigurer.Configure(
            builder,
            configuration.GetConnectionString(MPAConsts.ConnectionStringName)
        );

        return new MPADbContext(builder.Options);
    }
}