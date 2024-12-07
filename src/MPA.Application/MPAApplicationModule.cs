using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MPA;

[DependsOn(
    typeof(MPACoreModule),
    typeof(AbpAutoMapperModule))]
public class MPAApplicationModule : AbpModule
{
    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MPAApplicationModule).GetAssembly());
    }
}