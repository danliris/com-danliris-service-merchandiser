using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.AccessTokenValidation;
using Newtonsoft.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.WebApi.Helpers;

namespace Com.Danliris.Service.Merchandiser.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public void RegisterEndpoint()
        {
           
            //APIEndpoint.Production = Configuration.GetValue<string>("ProductionEndpoint") ?? Configuration["ProductionEndpoint"];
        }


      
        private void RegisterServices(IServiceCollection services)
        {
            services
               .AddScoped<IdentityService>()
               .AddScoped<ValidateService>()
               .AddScoped<IHttpClientService, HttpClientService>()
               .AddScoped<IIdentityService, IdentityService>()
               .AddScoped<IValidateService, ValidateService>();

        }


        //Ini modify dari copy paste
        private void RegisterBusinessServices(IServiceCollection services)
        {
            services
                 .AddTransient<IAzureStorageService, AzureStorageService>()
                 .AddTransient<IAzureImageService, AzureImageService>()
                 .AddTransient<IEfficiencies, EfficiencyService>()
                 .AddTransient<IArticleColor, ArticleColorService>()
                 .AddTransient<IRates, RateService>()
                 .AddTransient<ICostCalculationGarments, CostCalculationGarmentService>()
                 .AddTransient<IROGarment, RO_GarmentService>();

            services
                .AddTransient<RateService>()
                .AddTransient<EfficiencyService>()
                .AddTransient<CostCalculationGarmentService>()
                .AddTransient<CostCalculationGarment_MaterialService>()
                .AddTransient<LineService>()
                 .AddTransient<ArticleColorService>()
                .AddTransient<RO_GarmentService>()
                .AddTransient<RO_Garment_SizeBreakdownService>()
                //.AddTransient<IMapper>()
                .AddTransient<RO_Garment_SizeBreakdown_DetailService>();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection") ?? Configuration["DefaultConnection"];
            string env = Configuration.GetValue<string>(Constant.ASPNETCORE_ENVIRONMENT);
            services
                .AddDbContext<MerchandiserDbContext>(options => options.UseSqlServer(connectionString))
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                });



            
            #region Register
            RegisterServices(services);
            RegisterBusinessServices(services);
            RegisterEndpoint();
            services.AddAutoMapper();
            #endregion

            #region Authentication
            var Secret = Configuration.GetValue<string>("Secret") ?? Configuration["Secret"];
            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = false,
                        IssuerSigningKey = Key
                    };
                });

            #endregion

            #region CORS
            services.AddCors(options => options.AddPolicy("MerchandiserPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Content-Disposition", "api-version", "content-length", "content-md5", "content-type", "date", "request-id", "response-time");
            }));
            #endregion

            #region API
         
            services
               //  .AddApiVersioning(options => options.DefaultApiVersion = new ApiVersion(1, 0))
               .AddMvcCore()
               .AddApiExplorer()
               .AddAuthorization()
               .AddJsonFormatters()
               .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            #endregion

            services
                .AddMvcCore()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .AddAuthorization(options =>
                {
                    options.AddPolicy("service.core.read", (policyBuilder) =>
                    {
                        policyBuilder.RequireClaim("scope", "service.core.read");
                    });
                })
                .AddJsonFormatters();

            //#region Swagger
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info() { Title = "My API", Version = "v1" });
                    c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                    {
                        In = "header",
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization",
                        Type = "apiKey",
                    });
                    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>()
                {
                    {
                        "Bearer",
                        Enumerable.Empty<string>()
                    }
                });
                    c.CustomSchemaIds(i => i.FullName);
                });
            //#endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MerchandiserDbContext>();
                context.Database.Migrate();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseAuthentication();
            app.UseCors("MerchandiserPolicy");
            app.UseMvc();
        }
    }
}
