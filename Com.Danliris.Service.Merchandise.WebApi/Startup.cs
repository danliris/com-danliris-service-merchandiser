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
using Com.Danliris.Service.Merchandiser.Lib.Services;

namespace Com.Danliris.Service.Merchandiser.WebApi
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection") ?? Configuration["DefaultConnection"];

            services
                .AddDbContext<MerchandiserDbContext>(options => options.UseSqlServer(connectionString))
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                });

            services
                .AddTransient<AzureImageService>();

            services
                .AddTransient<SizeService>()
                .AddTransient<RateService>()

                .AddTransient<EfficiencyService>()
                .AddTransient<SizeRangeService>()
                .AddTransient<RelatedSizeService>()

                .AddTransient<CostCalculationGarmentService>()
                .AddTransient<CostCalculationGarment_MaterialService>()
                .AddTransient<LineService>()
                .AddTransient<ArticleColorService>()
                .AddTransient<RO_GarmentService>()
                .AddTransient<RO_Garment_SizeBreakdownService>()
                .AddTransient<RO_Garment_SizeBreakdown_DetailService>();

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

            services.AddCors(options => options.AddPolicy("MerchandiserPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Content-Disposition", "api-version", "content-length", "content-md5", "content-type", "date", "request-id", "response-time");
            }));
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
            app.UseAuthentication();
            app.UseCors("MerchandiserPolicy");
            app.UseMvc();
        }
    }
}
