#region Namespace
using Microsoft.Extensions.DependencyInjection;
using EFcoreRxweb.Infrastructure.Security;
using RxWeb.Core.Data;
using RxWeb.Core.Security;
using RxWeb.Core.Annotations;
using RxWeb.Core;
using EFcoreRxweb.UnitOfWork.DbEntityAudit;
using EFcoreRxweb.BoundedContext.Main;
            using EFcoreRxweb.UnitOfWork.Main;
            #endregion Namespace



namespace EFcoreRxweb.Api.Bootstrap
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
                        serviceCollection.AddScoped<ICandidateContext, CandidateContext>();
            serviceCollection.AddScoped<ICandidateUow, CandidateUow>();
                        serviceCollection.AddScoped<ICandidateLookupContext, CandidateLookupContext>();
            serviceCollection.AddScoped<ICandidateLookupUow, CandidateLookupUow>();
            #endregion ContextService





            #region DomainService
            
            #endregion DomainService
        }
    }
}




