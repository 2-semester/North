using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using North.Domain.Event;
using North.Domain.EventList;
using North.Domain.Location;
using North.Domain.Organization;
using North.Domain.SportCategory;
using North.Domain.SportCategoryType;
using North.Domain.Sportsman;
using North.Domain.SportsmanEvent;
using North.Infra.Event;
using North.Infra.EventList;
using North.Infra.Location;
using North.Infra.Organization;
using North.Infra.SportCategory;
using North.Infra.SportCategoryType;
using North.Infra.Sportsman;
using North.Infra.SportsmanEvent;
using North.Soft.Data;

namespace North.Soft
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();

            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<IEventListsRepository, EventListsRepository>();
            services.AddScoped<ILocationsRepository, LocationsRepository>();
            services.AddScoped<IOrganizationsRepository, OrganizationsRepository>();
            services.AddScoped<ISportCategoriesRepository, SportCategoriesRepository>();
            services.AddScoped<ISportCategoryTypesRepository, SportCategoryTypesRepository>();
            services.AddScoped<ISportsmenRepository, SportsmenRepository>();
            services.AddScoped<ISportsmanEventsRepository, SportsmanEventsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapRazorPages();
            });
        }
    }
}
