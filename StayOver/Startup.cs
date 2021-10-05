using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StayOver.Data;
using StayOver.Repos;
using StayOver.Repos.Interfaces;
using StayOver.Services;
using StayOver.Services.Interfaces;
using System;

namespace StayOver
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
            services.AddDbContext<StayOverDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("StayOverDbContextConnection")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IAdminRepo, AdminRepo>();
            services.AddScoped<IAccommodationRepo, AccommodationRepo>();
            services.AddScoped<IGalleryRepo, GalleryRepo>();
            services.AddScoped<IReservationRepo, ReservationRepo>();
            services.AddScoped<IReviewRepo, ReviewRepo>();

            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAccommodationService, AccommodationService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReviewService, ReviewService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });      
        }
    }
}
