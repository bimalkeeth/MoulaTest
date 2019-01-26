using System;
using System.IO;
using CommonContracts.Resources;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MoulaCustomers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BusinessRuleResource.Program_Main_Starting_Customer_GRPC_Server);
            BuildWebHost(args).Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            new WebHostBuilder().UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", false, true);
                })
                .UseStartup<Startup>().Build();
    }
}