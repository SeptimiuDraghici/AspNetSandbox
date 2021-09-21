using System;
using System.Linq;
using AspNetSandBox.Models;
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
                    Console.WriteLine("The books are here!");
                }
                else
                {
                    applicationDbContext.Add(new Book
                    {
                        Title = "Metro 2033",
                        Author = "Dmitry Glukhovsky",
                        Language = "Russian",
                    });
                    applicationDbContext.Add(new Book
                    {
                        Title = "Metro 2034",
                        Author = "Dmitry Glukhovsky",
                        Language = "Russian",
                    });
                    applicationDbContext.SaveChanges();
                    Console.WriteLine("No books so added two default books!");
                }
            }
        }
    }
}
