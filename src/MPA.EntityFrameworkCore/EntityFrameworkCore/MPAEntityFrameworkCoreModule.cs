using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MPA.EntityFrameworkCore;

[DependsOn(
    typeof(MPACoreModule),
    typeof(AbpEntityFrameworkCoreModule))]
public class MPAEntityFrameworkCoreModule : AbpModule
{
    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MPAEntityFrameworkCoreModule).GetAssembly());
    }
}