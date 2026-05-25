using Gunluq_Application.ApplicationAssembly;
using Gunluq_Domain.Enums;
using Gunluq_Infrastructure.Context;
using Gunluq_WebAPI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;
using System.Text;

namespace Gunluq_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            var key = Environment.GetEnvironmentVariable("JWT_KEY");
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("gunluq", policy =>
            //    {
            //        policy
            //            .WithOrigins(
            //        "http://localhost:5173",
            //        "https://snowlychat.netlify.app"
            //    )
            //    .AllowAnyHeader()
            //    .AllowAnyMethod()
            //    .AllowCredentials();
            //    });
            //});
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("gunluqPolicy", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(typeof(AppAssembly).Assembly);
            builder.Services.AddServices();
            builder.Services.ValidationRegistration();

            builder.Services.AddDbContext<GunluqDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!)),
                    RoleClaimType = ClaimTypes.Role,
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });
            
                builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT Token",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                opt.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly",
                    policy => policy.RequireRole(Role.Admin.ToString()));

                options.AddPolicy("UserOrAdmin",
                    policy => policy.RequireRole(
                        Role.User.ToString(),
                        Role.Admin.ToString()));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}



            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseCors("gunluqPolicy");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
