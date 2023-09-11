using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EFcoreRxweb.BoundedContext.SqlContext;
using EFcoreRxweb.Models.Main;
using EFcoreRxweb.Models;
using EFcoreRxweb.BoundedContext.Singleton;
using RxWeb.Core.Data;
using RxWeb.Core.Data.Models;
using RxWeb.Core.Data.BoundedContext;

namespace EFcoreRxweb.BoundedContext.Main
{
    public class CandidateLookupContext : BaseBoundedContext, ICandidateLookupContext
    {
        public CandidateLookupContext(MainSqlDbContext sqlDbContext,  IOptions<DatabaseConfig> databaseConfig, IHttpContextAccessor contextAccessor,ITenantDbConnectionInfo tenantDbConnection): base(sqlDbContext, databaseConfig.Value, contextAccessor,tenantDbConnection){ }

            #region DbSets
            		public DbSet<Country> Countries { get; set; }
            #endregion DbSets


    }


    public interface ICandidateLookupContext : IDbContext
    {
    }
}

