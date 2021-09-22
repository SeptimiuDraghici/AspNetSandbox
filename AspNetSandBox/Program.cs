using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetSandBox
{
    /// <summary>Main class.</summary>
    public class Program
    {
        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static int Main(string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine("There is 1 argument.");
            }
            else if(args.Length > 1)
            {
                Console.WriteLine($"There are {args.Length} arguments.");
            }
            else
            {
                Console.WriteLine("There are no arguments.");
            }

            CreateHostBuilder(args).Build().Run();
            return 0;
        }

        /// <summary>Creates the host builder.</summary>
        /// <param name="args">The arguments.</param>
        /// <returns>
        ///   HostBuilder object.
        /// </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
