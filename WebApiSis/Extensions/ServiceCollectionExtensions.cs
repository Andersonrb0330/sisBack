﻿using System.Text;
using Application.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebApiProject(this IServiceCollection services, IConfiguration configuration)
        {
            SetJwtConfig(services, configuration);
            SetCors(services);
        }

        public static void SetJwtConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 var jwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>();
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtConfig.Issuer,
                     ValidAudience = jwtConfig.Audience,
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(jwtConfig.Key))
                 };
             });
        }

        public static void SetCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200") // Reemplaza con la URL permitida
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }
    }
}

