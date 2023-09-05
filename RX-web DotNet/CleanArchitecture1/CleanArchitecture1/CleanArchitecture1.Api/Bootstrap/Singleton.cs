using CleanArchitecture1.BoundedContext.Singleton;
using CleanArchitecture1.Infrastructure.Singleton;
using Microsoft.Extensions.DependencyInjection;
using RxWeb.Core.Data;

namespace CleanArchitecture1.Api.Bootstrap
{
    public static class Singleton
    {
        public static void AddSingletonService(this IServiceCollection serviceCollection)
        {
            #region Singleton
            serviceCollection.AddSingleton<ITenantDbConnectionInfo, TenantDbConnectionInfo>();
            serviceCollection.AddSingleton(typeof(UserAccessConfigInfo));
            #endregion Singleton
        }

    }
}




