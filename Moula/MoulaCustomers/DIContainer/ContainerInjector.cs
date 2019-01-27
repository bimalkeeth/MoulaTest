using BIRuleManager.implementation;
using BIRuleManager.interfaces;
using BIRuleProcessor.Implementations;
using BIRuleProcessor.Interfaces;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories.Implementation;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MoulaCustomers.DIContainer
{
    public static class ContainerInjector
    {
        /// <summary>
        /// Setup Dependency constructor Injections for interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configuration"></param>
        public static void Config(IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<CustomerDbContext>(option=>option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            service.AddTransient<ICustomerRuleManager, CustomerRuleManager>();
            service.AddTransient<IAddressRuleProcessor, AddressRuleProcessor>();
            service.AddTransient<IContactsRuleProcessor, ContactsRuleProcessor>();
            service.AddTransient<ICustomerRulesProcessor, CustomerRulesProcessor>();
            service.AddTransient<IContactRuleManager, ContactRuleManager>();
            service.AddTransient<IAddressRuleManager, AddressRuleManager>();
            service.AddSingleton<IUnitOfWork, UnitOfWork>();
            service.AddSingleton<IRepositoryFactory, RepositoryFactory>();
        }
    }
}