using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MPA.Web.Startup;
namespace MPA.Web.Tests;

[DependsOn(
    typeof(MPAWebModule),
    typeof(AbpAspNetCoreTestBaseModule)
    )]
public class MPAWebTestModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MPAWebTestModule).GetAssembly());
    }
}