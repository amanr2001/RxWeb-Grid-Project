using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using prj1.BoundedContext.SqlContext;
using prj1.Models.Main;
using prj1.Models;
using prj1.BoundedContext.Singleton;
using RxWeb.Core.Data;
using RxWeb.Core.Data.Models;
using RxWeb.Core.Data.BoundedContext;

namespace prj1.BoundedContext.Main
{
    public class MasterContext : BaseBoundedContext, IMasterContext
    {
        public MasterContext(MainSqlDbContext sqlDbContext,  IOptions<DatabaseConfig> databaseConfig, IHttpContextAccessor contextAccessor,ITenantDbConnectionInfo tenantDbConnection): base(sqlDbContext, databaseConfig.Value, contextAccessor,tenantDbConnection){ }

            #region DbSets
  //          		public DbSet<vTest> vTests { get; set; }
		//public DbSet<Test> Tests { get; set; }
            		public DbSet<vTest> vTests { get; set; }
		public DbSet<vTestRecord> vTestRecords { get; set; }
		public DbSet<Test> Tests { get; set; }
            #endregion DbSets



    }


    public interface IMasterContext : IDbContext
    {
    }
}

