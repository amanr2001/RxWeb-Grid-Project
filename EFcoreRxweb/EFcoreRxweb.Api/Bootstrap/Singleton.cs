using Microsoft.Extensions.DependencyInjection;
using EFcoreRxweb.Infrastructure.Singleton;
using EFcoreRxweb.BoundedContext.Singleton;
using RxWeb.Core.Data;

namespace EFcoreRxweb.Api.Bootstrap
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




