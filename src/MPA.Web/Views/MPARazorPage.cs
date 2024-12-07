using Abp.AspNetCore.Mvc.Views;

namespace MPA.Web.Views
{
    public abstract class MPARazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected MPARazorPage()
        {
            LocalizationSourceName = MPAConsts.LocalizationSourceName;
        }
    }
}
