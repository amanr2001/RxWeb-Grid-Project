
using CleanArchitecture1.Api.Bootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using RxWeb.Core.AspNetCore.Extensions;
using RxWeb.Core.Extensions;
using Microsoft.AspNetCore.Authentication.Certificate;
using System.Security.Cryptography.X509Certificates;

namespace CleanArchitecture1.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
       .AddCertificate(options =>
       {
           options.AllowedCertificateTypes = CertificateTypes.All;
           options.RevocationMode = X509RevocationMode.NoCheck;
           // Configure other options as needed.
       });


            services.AddConfigurationOptions(Configuration);

            services.AddHttpContextAccessor();
            services.AddPerformance();
            services.AddSecurity(Configuration);
            services.AddSingletonService();
            services.AddScopedService();
            services.AddDbContextService();
            services.AddControllers();
            services.AddSwaggerOptions();
            services.AddMvc(options =>
            {
                options.AddRxWebSanitizers();
                options.AddValidation();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddNewtonsoftJson(
                oo =>
                {
                    var resolver = new CamelCasePropertyNamesContractResolver();
                    if (resolver != null)
                    {
                        var res = resolver as DefaultContractResolver;
                        res.NamingStrategy = null;
                    }
                    oo.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePerformance();

            app.UseRouting();
            app.UseAuthentication(); // Add this line to enable authentication.
            app.UseAuthorization();

            app.UseSecurity(env);



            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



