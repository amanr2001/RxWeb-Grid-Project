using Microsoft.Extensions.DependencyInjection;
using prj1.Infrastructure.Singleton;
using prj1.BoundedContext.Singleton;
using RxWeb.Core.Data;

namespace prj1.Api.Bootstrap
{
    public static class Singleton
    {
        public static void AddSingletonService(this IServiceCollection serviceCollection) {
            #region Singleton
            serviceCollection.AddSingleton<ITenantDbConnectionInfo, TenantDbConnectionInfo>();
            serviceCollection.AddSingleton(typeof(UserAccessConfigInfo));
            #endregion Singleton
        }

    }
}




