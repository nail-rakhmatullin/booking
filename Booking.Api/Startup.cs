using Booking.Api.Middlewares;
using Booking.BusinessLayer;
using Booking.BusinessLayer.Abstract;
using Booking.BusinessLayer.Factories;
using Booking.BusinessLayer.MapperProfiles;
using Booking.BusinessLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Booking.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Booking.Api", Version = "v1"});
            });

            services.InjectDatalayer(Configuration)
                .AddDatabaseConfiguration(Configuration);
            
            services.AddAutoMapper(typeof(BookingProfile));
            services.AddScoped<IResponseFactory, ResponseFactory>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IApartamentService, ApartamentService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<ICompanyService, CompanmyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking.Api v1"));
            }

            app.UseMiddleware<GlobalApiErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}