using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TourismReserve.BL;
using TourismReserve.BL.Extensions;
using TourismReserve.Core.Models.Commons;
using TourismRserve.DAL;
using TourismRserve.DAL.Context;

namespace TourismReserve
{
    public class Program
    {
        private readonly IWebHostEnvironment _env;

        public Program(IWebHostEnvironment env)
        {
            _env = env;
        }
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireUppercase = true;

                opt.Password.RequireLowercase = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireDigit = true;
                opt.Lockout.MaxFailedAccessAttempts = 1;

                opt.Password.RequireLowercase = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireDigit = true;
                opt.Lockout.MaxFailedAccessAttempts = 1;

                opt.Password.RequireNonAlphanumeric = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);

            }).AddDefaultTokenProviders().AddEntityFrameworkStores<TourismDbContext>();

            builder.Services.AddDbContext<TourismDbContext>(opt=>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSsql"));
            });
            builder.Services.AddRepositories();
            builder.Services.AddService();
            builder.Services.AddAutoMapper();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseUserSeed();
            app.UseRouting();

            app.UseAuthorization();
            
              app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
                );
           
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
