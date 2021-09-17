using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AspNetSandBox.Data;
using AspNetSandBox.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace AspNetSandBox
{
    /// <summary>Class for initial configuration of app.</summary>
    public class Startup
    {
        /// <summary>Initializes a new instance of the <see cref="Startup" /> class.</summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>Gets configuration.</summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        public static string ConvertConnectionString(string connectionString)
        {
            Uri uri = new Uri(connectionString);
            string convertedString = "Database=" + uri.AbsolutePath.TrimStart('/') + "; ";
            convertedString += "Host=" + uri.Host + "; ";
            convertedString += "Port=" + uri.Port + "; ";
            string[] user = uri.UserInfo.Split(':');
            convertedString += "User Id=" + user[0] + "; ";
            convertedString += "Password=" + user[1] + "; ";
            convertedString += "SSL Mode=Require;Trust Server Certificate=true";
            return convertedString;
        }

        /// <summary>Add and configure services in the container to be used for webapp.</summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(GetConnectionString()));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiSandbox", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
            services.AddScoped<IBookRepository, DbBooksRepository>();
            services.AddSignalR();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>Configures the HTTP request pipeline.</summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiSandbox v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            var defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames = new List<string>();
            defaultFilesOptions.DefaultFileNames.Add("index.html");

            app.UseHttpsRedirection();
            app.UseDefaultFiles(defaultFilesOptions);
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
                endpoints.MapControllers();
                endpoints.MapHub<MessageHub>("/messagehub");
            });
        }

        private string GetConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
            if (connectionString != null)
            {
                return ConvertConnectionString(connectionString);
            }

            return Configuration.GetConnectionString("HerokuPostgresConnection");
        }

    }
}
