using DCAS_PracticalExam.Context;
using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
using DCAS_PracticalExam.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //string cs = "Server=DESKTOP-INO782J;Database=PracticalExam;Trusted_connection=True;MultipleActiveResultSets=True;";

            services.AddDbContext<PracticalExamContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //services.AddDbContext<PracticalExamContext>(o =>
            //{
            //    o.UseSqlServer(cs);
            //});

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped(typeof(ICommonServices<>), typeof(CommonServices<>));
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<PracticalExamContext>();
            services.Configure<SmtpConfig>(Configuration.GetSection("SmtpConfig"));
            services.Configure<IdentityOptions>(options =>
            {
                //options.Password.RequiredLength = 5;
                //options.Password.RequiredUniqueChars = 0;
                //options.Password.RequireDigit = false;
                //options.Password.RequireLowercase = false;
                //options.Password.RequireUppercase = false;
                //options.Password.RequireNonAlphanumeric = false;

                options.SignIn.RequireConfirmedEmail = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = Configuration.GetValue<int>("MaxLogAttempt");

            });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = Configuration["Application:LoginPath"];
            });
            // Add services to the container.
            services.AddHttpClient();
            services.AddSingleton<IApiConsume, ApiConsumeRepo>();
            services.AddScoped<IApiService, ApiService>();
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {

            // AUTO MIGRATION
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PracticalExamContext>();
                dbContext.Database.Migrate(); // Apply any pending migrations
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            });
        }
    }
}
