using AutoMapper;
using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.PerformanceParticipation.Api;
using DhubSolutions.PerformanceParticipation.Api.Extensions;
using DhubSolutions.PerformanceParticipation.Api.Filters;
using DhubSolutions.PerformanceParticipation.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DhubSolutions.PerformanceParticipationReport.Api
{
    public partial class Startup
    {
        private readonly IEnumerable<Assembly> assemblies;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            assemblies = LoadAssemblies();

            IEnumerable<Assembly> LoadAssemblies()
            {
                Assembly entryAssembly = Assembly.GetEntryAssembly();
                List<Assembly> assemblies = new List<Assembly> { entryAssembly };
                assemblies.AddRange(entryAssembly.GetReferencedAssemblies()
                       .Select(assemblyName => Assembly.Load(assemblyName)));
                return assemblies;

            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Register Api Versioning
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Performance Participation API", Version = "v1" });

                option.SwaggerDoc("v2", new OpenApiInfo { Title = "Performance Participation API", Version = "v2" });

                option.DocInclusionPredicate((docName, apiDescription) =>
                {
                    ApiVersionModel apiVersionModel = apiDescription.ActionDescriptor?.GetApiVersion();
                    if (apiVersionModel == null)
                        return true;

                    return apiVersionModel.DeclaredApiVersions.Any()
                        ? apiVersionModel.DeclaredApiVersions.Any(version => $"v{version}" == docName)
                        : apiVersionModel.ImplementedApiVersions.Any(version => $"v{version}" == docName);

                });

                option.OperationFilter<RemoveVersionParameterFilter>();

                option.DocumentFilter<SetVersionInPathFilter>();

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header {token}",
                    Name = "Authorization",
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,

                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });

                option.DescribeAllParametersInCamelCase();


            });
            services.AddSwaggerGenNewtonsoftSupport();

            #region Application Insights
            services.AddApplicationInsightsTelemetry(Configuration);
            #endregion

            var token = Configuration.GetSection("TokenManagement").Get<TokenManagement>();
            var secret = Encoding.ASCII.GetBytes(token.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                };
            });

            // Register the DbContext 
            var connectionString = Configuration.GetConnectionString("performanceParticipation");
            services.AddDbContextPool<PerformanceParticipationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });


            //Adds and configures Identity for the specified user class
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<PerformanceParticipationDbContext>()
            .AddDefaultTokenProviders();

            // Scans assemblies and:
            // adds profiles to mapping configuratios
            // adds value resolvers, member value resolvers, type converters to the container.            
            services.AddAutoMapper(assemblies, ServiceLifetime.Scoped);

            ConfigureDependencies(Configuration, services);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyOrigin();
                c.AllowAnyMethod();
                c.AllowAnyHeader();
                c.AllowCredentials();
            });

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Performance Participation API v1");

                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Performance Participation API v2");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }


}
