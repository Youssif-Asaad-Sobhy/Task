﻿using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MPA.Configuration;
using MPA.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace MPA.Web.Startup
{
    [DependsOn(
        typeof(MPAApplicationModule),
        typeof(MPAEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreModule))]
    public class MPAWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MPAWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MPAConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<MPANavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MPAApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MPAWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MPAWebModule).Assembly);
        }
    }
}
