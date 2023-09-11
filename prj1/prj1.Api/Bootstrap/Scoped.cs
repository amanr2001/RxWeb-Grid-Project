#region Namespace
using Microsoft.Extensions.DependencyInjection;
using prj1.Infrastructure.Security;
using RxWeb.Core.Data;
using RxWeb.Core.Security;
using RxWeb.Core.Annotations;
using RxWeb.Core;
using prj1.UnitOfWork.DbEntityAudit;
using prj1.BoundedContext.Main;
            using prj1.UnitOfWork.Main;
            #endregion Namespace



namespace prj1.Api.Bootstrap
{
    public static class ScopedExtension
    {

        public static void AddScopedService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepositoryProvider, RepositoryProvider>();
            serviceCollection.AddScoped<ITokenAuthorizer, TokenAuthorizer>();
            serviceCollection.AddScoped<IModelValidation, ModelValidation>();
			serviceCollection.AddScoped<IAuditLog, AuditLog>();
			serviceCollection.AddScoped<IApplicationTokenProvider, ApplicationTokenProvider>();

            #region ContextService

                        serviceCollection.AddScoped<ILoginContext, LoginContext>();
            serviceCollection.AddScoped<ILoginUow, LoginUow>();
                        serviceCollection.AddScoped<IMasterContext, MasterContext>();
            serviceCollection.AddScoped<IMasterUow, MasterUow>();
            #endregion ContextService




            #region DomainService
            
            #endregion DomainService
        }
    }
}




