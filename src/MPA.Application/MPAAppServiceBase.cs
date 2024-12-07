using Abp.Application.Services;

namespace MPA;

/// <summary>
/// Derive your application services from this class.
/// </summary>
public abstract class MPAAppServiceBase : ApplicationService
{
    protected MPAAppServiceBase()
    {
        LocalizationSourceName = MPAConsts.LocalizationSourceName;
    }
}