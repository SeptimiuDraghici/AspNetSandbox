using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetSandBox.Data
{
    public static class DataTools
    {
        public static void SeedData(this IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (applicationDbContext.Book.Any())
                {
                    Console.WriteLine("The Books are here!");
                }
                else
                {
                    Console.WriteLine("No Books found!");
                }
            }
        }
    }
}
