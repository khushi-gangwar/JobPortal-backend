using FluentValidation;
using FluentValidation.AspNetCore;
using JobPortal.Data;
using JobPortal.Features.Auth.Validator;
using JobPortal.Models;
using JobPortal.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace JobPortal.Extensions
{
    
        public static class ServiceCollectionExtensions
        {
            public static IServiceCollection AddDevSpotServices(this IServiceCollection services, IConfiguration config)
            {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(
                    config.GetConnectionString("default"),
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                );
            });
            services.AddIdentity<UserModel, IdentityRole>()
                  .AddEntityFrameworkStores<AppDbContext>()
                  .AddDefaultTokenProviders();
          

            // JWT Authentication
            var jwtKey = config["Jwt:Key"];
            var jwtIssuer = config["Jwt:Issuer"];
            var jwtAudience = config["Jwt:Audience"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAuthorization();
            services.AddValidatorsFromAssemblyContaining<RegisterDtoValidator>();
            services.AddFluentValidationAutoValidation();

            services.AddSingleton<IJwtService, JwtService>();
           
            return services;
        }
    }
    }

