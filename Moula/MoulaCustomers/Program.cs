using System;
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using BIRuleManager.implementation;
using BIRuleManager.interfaces;
using BIRuleProcessor.Implementations;
using BIRuleProcessor.Interfaces;
using BIRuleProcessor.Mapppers;
using CommonContracts;
using CommonContracts.Resources;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories.Implementation;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoulaCustomers.DIContainer;

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