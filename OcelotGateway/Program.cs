using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OcelotGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "OcelotGateway";
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            IWebHostBuilder builder = new WebHostBuilder();
            return builder.ConfigureServices(service =>
            {
                service.AddSingleton(builder);
            }).ConfigureAppConfiguration(conbulder =>
            {
                conbulder.AddJsonFile("appsettings.json");
                conbulder.AddJsonFile("configuration.json");
            }).UseContentRoot(Directory.GetCurrentDirectory())
            .UseKestrel()
            .UseUrls("http://192.168.196.128:5000")
            .UseStartup<Startup>()
            .Build();
        }

    }
}
