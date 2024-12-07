using Abp.TestBase;
using MPA.EntityFrameworkCore;
using MPA.Tests.TestDatas;
using System;
using System.Threading.Tasks;

namespace MPA.Tests;

public class MPATestBase : AbpIntegratedTestBase<MPATestModule>
{
    public MPATestBase()
    {
        UsingDbContext(context => new TestDataBuilder(context).Build());
    }

    protected virtual void UsingDbContext(Action<MPADbContext> action)
    {
        using (var context = LocalIocManager.Resolve<MPADbContext>())
        {
            action(context);
            context.SaveChanges();
        }
    }

    protected virtual T UsingDbContext<T>(Func<MPADbContext, T> func)
    {
        T result;

        using (var context = LocalIocManager.Resolve<MPADbContext>())
        {
            result = func(context);
            context.SaveChanges();
        }

        return result;
    }

    protected virtual async Task UsingDbContextAsync(Func<MPADbContext, Task> action)
    {
        using (var context = LocalIocManager.Resolve<MPADbContext>())
        {
            await action(context);
            await context.SaveChangesAsync(true);
        }
    }

    protected virtual async Task<T> UsingDbContextAsync<T>(Func<MPADbContext, Task<T>> func)
    {
        T result;

        using (var context = LocalIocManager.Resolve<MPADbContext>())
        {
            result = await func(context);
            context.SaveChanges();
        }

        return result;
    }
}
