using ComplantSystem;
using ComplantSystem.Areas;
using ComplantSystem.Areas.AdminGeneralFederation.Service;
using ComplantSystem.Areas.AdminService.Service;
using ComplantSystem.Areas.Beneficiaries.Data.Base;
using ComplantSystem.Areas.VillagesUsers.Service;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ComplantSystem
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
            services.AddControllersWithViews();


            services.AddDbContext<AppCompalintsContextDB>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });


            //services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //{

            //}).AddEntityFrameworkStores<AppCompalintsContextDB>();



            // Add services to the container.

            services.AddScoped<ICompalintService, CompalintService>();
            services.AddScoped<IVillageService, VillageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISolveCompalintService, SolveCompalintService>(); 
            services.AddScoped<ILocationRepo<Governorate>, GovernorateRepo>();
            services.AddScoped<ILocationRepo<Directorate>, DirectorateRepo>();
            services.AddScoped<ILocationRepo<SubDirectorate>, SubDirectorateRepo>();
            services.AddScoped<ILocationRepo<Village>, VillageRepo>(); 
            services.AddAdminServices();

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppCompalintsContextDB>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            // Add services to the container.



            services.AddAutoMapper(typeof(Startup));


        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseHttpsRedirection();



            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                 name: "Beneficiarie",
                 pattern: "{area:exists}/{controller=Complaints}/{action=Index}/{id?}"
               );
                endpoints.MapControllerRoute(
                name: "AdminGeneralFederation",
                pattern: "{area:exists}/{controller=ManageCategoryes}/{action=Index}/{id?}"
              );



                endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}