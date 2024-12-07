using Abp.AspNetCore.Mvc.Controllers;

namespace MPA.Web.Controllers
{
    public abstract class MPAControllerBase : AbpController
    {
        protected MPAControllerBase()
        {
            LocalizationSourceName = MPAConsts.LocalizationSourceName;
        }
    }
}