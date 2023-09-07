using Microsoft.Extensions.DependencyInjection;
using TestProject.Infrastructure.Singleton;
using TestProject.BoundedContext.Singleton;
using RxWeb.Core.Data;

namespace TestProject.Api.Bootstrap
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




