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
            //BuildWebHost(args).Run();

            var mapping = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfiguration() );
            });
            
            var serviceProvider = new ServiceCollection()
                                    .AddLogging()
                                    .AddDbContext<CustomerDbContext>(option=>option.UseSqlServer("Server=localhost;Database=CustomersDb;User=sa;Password=Scala@1234;"))
                                    .AddTransient<ICustomerRuleManager, CustomerRuleManager>()
                                    .AddTransient<IAddressRuleProcessor, AddressRuleProcessor>()
                                    .AddTransient<IContactsRuleProcessor, ContactsRuleProcessor>()
                                    .AddTransient<ICustomerRulesProcessor, CustomerRulesProcessor>()
                                    .AddTransient<IUnitOfWork, UnitOfWork>()
                                    .AddSingleton<IRepositoryFactory,RepositoryFactory>()
                                    .AddSingleton(mapping.CreateMapper())
                                    .BuildServiceProvider();

           var customer= serviceProvider.GetService<ICustomerRuleManager>();
           
           var context = serviceProvider.GetRequiredService<CustomerDbContext>();
           context.Database.EnsureCreated();
           
           customer.CreateCustomer(new CustomerBo
           {
               LastName = "KaluarachchiC",
               FirstName = "Bimal",
               DateOfBirth = DateTime.Now,
               CustomerAddress = new List<CustomerAddressBo>
               {
                   new CustomerAddressBo
                   {
                       IsPrimary = true,
                       Address = new AddressBo
                       {
                           Street = "2/5",
                           Street2 = "Wattle Road",
                           Suburb = "Maidstone",
                           Country = "Australia",
                           AddressTypeId = 1,
                           StateId = 2
                       }
                   }
               },
               CustomerContacts = new List<CustomerContactsBo>
               {
                   new CustomerContactsBo
                   {
                       IsPrimary = true,
                       Contact = new ContactsBo
                       {
                           Contact = "bimalkeeth@gmail.com",
                           ContactTypeId = 1
                       }
                   }
               }
               
           });

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