using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using WebApplication2.Interfaces;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.Service;

namespace WebApplication2
{
    public class Program
    {
          
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddDbContext<MiniprojectContext>();
            builder.Services.AddDbContext<MiniprojectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<Icity,CityRepo>();
            builder.Services.AddTransient<Icar, CarRepo>();
            builder.Services.AddTransient<Iimage, ImageRepo>();
            builder.Services.AddTransient<Iobject, ObjectRepo>();
            builder.Services.AddTransient<IobjType, ObjtypeRepo>();
            builder.Services.AddTransient<Iuser, userRepo>();
            builder.Services.AddTransient<Ioutlet, OutletRepo>();
            builder.Services.AddTransient<Itestdrive, TestdriveRepo>();
            builder.Services.AddTransient<Iservice, ServiceRepo>();
            builder.Services.AddTransient<Iorderitem, OrderItemRepo>();
            builder.Services.AddTransient<Iorder, OrderRepo>();
            builder.Services.AddTransient<Razorpayservice,Razorpayservice>();
            builder.Services.AddTransient<Irole, RoleRepo>();
            builder.Services.AddTransient<Ipayment, PaymentRepo>();
            builder.Services.AddTransient<Invoiceservice, Invoiceservice>();
            builder.Services.AddTransient<Iwishlist,WishlistRepo>();
            builder.Services.AddTransient<ImainPage, MainPageRepo>();
            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //builder.Services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options =>
                    options.WithOrigins("http://localhost:4200") // Specify the allowed origin
                           .AllowCredentials()                  // Allow credentials
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });
            builder.Services.AddSwaggerGen();

            var tk = builder.Configuration.GetSection("Jwt");

            var tokenval = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = tk["Issuer"],
                ValidAudience = tk["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tk["key"]))
            };

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = tokenval;
                })
                ;


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}