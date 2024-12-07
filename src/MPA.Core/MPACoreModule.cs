using Abp.Modules;
using Abp.Reflection.Extensions;
using MPA.Localization;

namespace MPA;

public class MPACoreModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Auditing.IsEnabledForAnonymousUsers = true;

        MPALocalizationConfigurer.Configure(Configuration.Localization);

        Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = MPAConsts.DefaultPassPhrase;
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MPACoreModule).GetAssembly());
    }
}