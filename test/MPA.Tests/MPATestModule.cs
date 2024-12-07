using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.TestBase;
using MPA.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MPA.Tests;

[DependsOn(
    typeof(MPAApplicationModule),
    typeof(MPAEntityFrameworkCoreModule),
    typeof(AbpTestBaseModule)
    )]
public class MPATestModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        SetupInMemoryDb();
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MPATestModule).GetAssembly());
    }

    private void SetupInMemoryDb()
    {
        var services = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase();

        var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(
            IocManager.IocContainer,
            services
        );

        var builder = new DbContextOptionsBuilder<MPADbContext>();
        builder.UseInMemoryDatabase("Test").UseInternalServiceProvider(serviceProvider);

        IocManager.IocContainer.Register(
            Component
                .For<DbContextOptions<MPADbContext>>()
                .Instance(builder.Options)
                .LifestyleSingleton()
        );
    }
}